using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vouchers.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Vouchers.BusinessLogic.Abstractions;

namespace Vouchers.BusinessLogic
{
    public class BackGroudService : IHostedService
    {
        private readonly IVoucherFileProcessorTaskes _tasks;
        private CancellationTokenSource _tokenSource;
        private Task _currentTask;
        private readonly IServiceProvider _serviceProvider;
        public BackGroudService(IVoucherFileProcessorTaskes taskes,
            IServiceProvider serviceProvider) {
            _tasks = taskes;
            _serviceProvider = serviceProvider;
        }

        private Task ExecuteTask(UploadedFile file, CancellationToken token) {
            IVoucherFileProcessor processor = _serviceProvider.GetService<IVoucherFileProcessor>();
            return processor.ProcessFile(file.FullPath);
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _tokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            while (cancellationToken.IsCancellationRequested == false) {
                try
                {
                    
                    var taskToRun = _tasks.DeQueue(_tokenSource.Token);
                    _currentTask = ExecuteTask(taskToRun, _tokenSource.Token);
                    await _currentTask;
                }
                catch (Exception e) { 
                }
            }
            throw new NotImplementedException();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _tokenSource.Cancel();
            if (_currentTask == null) return;
            await Task.WhenAll(_currentTask, Task.Delay(Timeout.Infinite, cancellationToken));
        }
    }
}

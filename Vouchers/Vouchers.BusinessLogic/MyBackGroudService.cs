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
    public class MyBackGroudService : BackgroundService
    {
        private readonly IVoucherFileProcessorTaskes _tasks;
        private CancellationTokenSource _tokenSource;
        private Task _currentTask;
        private readonly IServiceProvider _serviceProvider;
        public MyBackGroudService(IVoucherFileProcessorTaskes taskes,
            IServiceProvider serviceProvider) {
            _tasks = taskes;
            _serviceProvider = serviceProvider;
        }

        private Task ExecuteTask(UploadedFile file, CancellationToken token) {
            using var scope = _serviceProvider.CreateScope();
            var ssp = scope.ServiceProvider;
            IVoucherFileProcessor processor = ssp.GetRequiredService<IVoucherFileProcessor>();
            return processor.ProcessFile(file.FullPath);
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                 var workItem =
                    await _tasks.DeQueue(stoppingToken);

                try
                {
                    await ExecuteTask(workItem,stoppingToken);
                }
                catch (Exception ex)
                {
                    //_logger.LogError(ex,
                    //    "Error occurred executing {WorkItem}.", nameof(workItem));
                }
            }
        }
    }
}

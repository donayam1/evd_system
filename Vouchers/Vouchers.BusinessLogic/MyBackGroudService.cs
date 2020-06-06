using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vouchers.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Vouchers.BusinessLogic.Abstractions;
using Microsoft.Extensions.Logging;

namespace Vouchers.BusinessLogic
{
    public class MyBackGroudService : BackgroundService
    {
        private readonly IVoucherFileProcessorTaskes _tasks;        
        private readonly IServiceProvider _serviceProvider;

        private readonly ILogger<MyBackGroudService> _logger;
        public MyBackGroudService(IVoucherFileProcessorTaskes taskes,
            IServiceProvider serviceProvider,
            ILogger<MyBackGroudService> logger) {
            _tasks = taskes;
            _serviceProvider = serviceProvider ??
                throw new ArgumentNullException(nameof(serviceProvider));
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
        }

        private Task ExecuteTask(UploadedFile file, CancellationToken token) {
            using var scope = _serviceProvider.CreateScope();
            var ssp = scope.ServiceProvider;
            IVoucherFileProcessor processor = ssp.GetRequiredService<IVoucherFileProcessor>();
            return processor.ProcessFile(file.FullPath,file.PurchaseOrderId);
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
                    _logger.LogError(ex,
                        "Error occurred executing {WorkItem}.", nameof(workItem));
                }
            }
        }
    }
}

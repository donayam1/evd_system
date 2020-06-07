using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vouchers.BusinessLogic.Abstractions;
using Vouchers.ViewModels;

namespace Vouchers.BusinessLogic
{
    public class VoucherFileProcessorTaskes: IVoucherFileProcessorTaskes
    {
        private readonly ConcurrentQueue<UploadedFile> _tasks;        
        private SemaphoreSlim _signal = new SemaphoreSlim(0);
        public VoucherFileProcessorTaskes() {
            _tasks = new ConcurrentQueue<UploadedFile>();
            //this.Enqueue(new UploadedFile(false, ""));
        }
        public void Enqueue(UploadedFile voucherFileProcessor) {
            _tasks.Enqueue(voucherFileProcessor);
            _signal.Release();
        }
        public async Task<UploadedFile?> DeQueue(CancellationToken token) {
            await _signal.WaitAsync(token);
            _tasks.TryDequeue(out var workItem);
            return workItem;
            //return _tasks.Take(token);
        }
        
    }
}

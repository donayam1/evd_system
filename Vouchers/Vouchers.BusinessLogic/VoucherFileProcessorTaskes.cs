using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Vouchers.BusinessLogic.Abstractions;
using Vouchers.ViewModels;

namespace Vouchers.BusinessLogic
{
    public class VoucherFileProcessorTaskes: IVoucherFileProcessorTaskes
    {
        private readonly BlockingCollection<UploadedFile> _tasks;
        public VoucherFileProcessorTaskes() {
            _tasks = new BlockingCollection<UploadedFile>(new ConcurrentQueue<UploadedFile>(),100);
        }
        public void Enqueue(UploadedFile voucherFileProcessor) {
            _tasks.Add(voucherFileProcessor);
        }
        public UploadedFile DeQueue(CancellationToken token) {
            return _tasks.Take(token);
        }

    }
}

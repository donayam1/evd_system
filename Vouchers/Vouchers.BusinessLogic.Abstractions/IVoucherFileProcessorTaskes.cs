using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Vouchers.ViewModels;

namespace Vouchers.BusinessLogic.Abstractions
{
    public interface IVoucherFileProcessorTaskes
    {
         void Enqueue(UploadedFile voucherFileProcessor);       
         UploadedFile DeQueue(CancellationToken token);
        
    }
}

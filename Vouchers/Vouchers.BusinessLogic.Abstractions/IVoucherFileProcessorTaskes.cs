using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vouchers.ViewModels;

namespace Vouchers.BusinessLogic.Abstractions
{
    public interface IVoucherFileProcessorTaskes
    {
         void Enqueue(UploadedFile voucherFileProcessor);       
         Task<UploadedFile?> DeQueue(CancellationToken token);
        
    }
}

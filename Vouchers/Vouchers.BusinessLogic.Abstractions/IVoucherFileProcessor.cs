using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vouchers.ViewModels;

namespace Vouchers.BusinessLogic.Abstractions
{
    public interface IVoucherFileProcessor
    {
        Task ProcessFile(String path,String poId);
    }
}

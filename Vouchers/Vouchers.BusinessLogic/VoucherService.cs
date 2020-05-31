using EthioArt.Backend.Models.Requests;
using ExtCore.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vouchers.BusinessLogic.Abstractions;
using Vouchers.Data.Abstractions;
using Vouchers.ViewModels;
using Vouchers.ObjectMapper;

namespace Vouchers.BusinessLogic
{
    public class VoucherService : IVoucherService
    {
        private readonly IStorage _storage;
        private readonly IVouchersRepository _vouchersRepository;

        public VoucherService(IStorage storage) {
            _storage = storage ?? 
                throw new ArgumentNullException(nameof(IStorage));
            _vouchersRepository = _storage.GetRepository<IVouchersRepository>() ??
                throw new ArgumentNullException(nameof(IVouchersRepository));
        }

        public List<VoucherModel> ListVoutchers(PagedItemRequestBase request)
        {
            return _vouchersRepository.All().ToList().ToViewModel();
        }

        public void UpdateVoutcher()
        {
            throw new NotImplementedException();
        }
    }
}

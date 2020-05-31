using ExtCore.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Vouchers.BusinessLogic.Abstractions;
using Vouchers.Data.Abstractions;

namespace Vouchers.BusinessLogic
{
    public class VoucherService : IVotureService
    {
        private readonly IStorage _storage;
        private readonly IVouchersRepository _vouchersRepository;

        public VoucherService(IStorage storage) {
            _storage = storage ?? 
                throw new ArgumentNullException(nameof(IStorage));
            _vouchersRepository = _storage.GetRepository<IVouchersRepository>() ??
                throw new ArgumentNullException(nameof(IVouchersRepository));
        }

        public void ListVoutchers()
        {
            throw new NotImplementedException();
        }

        public void UpdateVoutcher()
        {
            throw new NotImplementedException();
        }
    }
}

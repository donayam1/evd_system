using EthioArt.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakTec.Accounting.Data.Abstractions;
using TakTec.Accounting.Entities;

namespace TakTec.Accounting.EntityFramework
{
    public class AirTimeRepository :
        GenericRepositoryBase<AirTime>,
        IAirTimeRepository
    {
        public override IQueryable<AirTime> LoadNavigationProperties(IQueryable<AirTime> items)
        {
            throw new NotImplementedException();
        }
    }
}

using EthioArt.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakTec.Accounting.Data.Abstractions;
using TakTec.Accounting.Entities;

namespace TakTec.Accounting.EntityFramework
{
    public class AirTimeUpdateRepository :
        GenericRepositoryBase<AirTimeUpdate>,
        IAirTimeUpdateRepository
    {
        public override IQueryable<AirTimeUpdate> LoadNavigationProperties(IQueryable<AirTimeUpdate> items)
        {
            throw new NotImplementedException();
        }
    }
}

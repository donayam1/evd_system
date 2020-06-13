using EthioArt.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakTec.Accounting.Data.Abstractions;
using TakTec.Accounting.Entities;
using Microsoft.EntityFrameworkCore;

namespace TakTec.Accounting.EntityFramework
{
    public class AirTimeUpdateRepository :
        GenericRepositoryBase<AirTimeUpdate>,
        IAirTimeUpdateRepository
    {
        public override IQueryable<AirTimeUpdate> LoadNavigationProperties(IQueryable<AirTimeUpdate> items)
        {
            return items.Include(x => x.AirTime);
        }
    }
}

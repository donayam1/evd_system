using EthioArt.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakTec.RetailerPlans.Abstractions;
using TakTec.RetailerPlans.Entities;
using Microsoft.EntityFrameworkCore;

namespace TakTec.RetailerPlans.EntityFramework
{
    public class UserPlanRepository : GenericRepositoryBase<UserPlan>,
        IUserPlanRepository
    {
        public override IQueryable<UserPlan> LoadNavigationProperties(IQueryable<UserPlan> items)
        {
            return items.Include(x => x.RetailerPlan);
        }

        public UserPlan? GetCurrentPlan(String ownerId) {
            return this.WithOwnerItemId(ownerId).Where(x => x.IsCurrent == true).FirstOrDefault();
        }

    }
}

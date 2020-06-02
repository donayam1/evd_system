using System;
using System.Linq;
using EthioArt.Data.EntityFramework;
using TakTec.RetailerPlans.Abstractions;
using TakTec.RetailerPlans.Entities;

namespace TakTec.RetailerPlans.EntityFramework
{
    public class RetailerPlanRepository : GenericRepositoryBase<RetailerPlan>, IRetailerPlanRepository
    {
        public override IQueryable<RetailerPlan> LoadNavigationProperties(IQueryable<RetailerPlan> items)
        {
            throw new NotImplementedException();
        }
    }
}

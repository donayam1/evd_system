using System;
using System.Collections.Generic;
using System.Linq;
using EthioArt.Data.EntityFramework;
using TakTec.RetailerPlans.Abstractions;
using TakTec.RetailerPlans.Entities;
using TakTec.Users.Constants;
namespace TakTec.RetailerPlans.EntityFramework
{
    public class RetailerPlanRepository : GenericRepositoryBase<RetailerPlan>, IRetailerPlanRepository
    {

        public override IQueryable<RetailerPlan> LoadNavigationProperties(IQueryable<RetailerPlan> items)
         {
             throw new NotImplementedException();
         }

         public RetailerPlan WithCodeorWithName(RetailerPlan retailerPlan)
         {
             var plan = All().Where(x =>
                        (x.Code == retailerPlan.Code || x.Name == retailerPlan.Name)&&
                        (x.Id != retailerPlan.Id)).FirstOrDefault();
             return plan;
         }
         
        public List<RetailerPlan> Getplans(string userRole)
        {
            var userPlans = WithOwnerItemId(userRole);
            var systemPlans = WithOwnerItemId(RoleTypeConstants.RoleNameSupperAdmin);

            List<RetailerPlan> allPlans = systemPlans.Concat(userPlans).ToList();

            return allPlans;

        }

         
    }
}

using EthioArt.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using TakTec.RetailerPlans.Entities;

namespace TakTec.RetailerPlans.Abstractions
{
    public interface IUserPlanRepository
        :IGenericRepository<UserPlan>
    {
        UserPlan? GetCurrentPlan(String ownerId);
    }
}

using Microsoft.VisualBasic.CompilerServices;
using System.Reflection.Metadata;
using System;
using EthioArt.Data.Abstraction;
using TakTec.RetailerPlans.Entities;
using ExtCore.Data.Abstractions;
using System.Collections.Generic;

namespace TakTec.RetailerPlans.Abstractions
{
    public interface IRetailerPlanRepository:IGenericRepository<RetailerPlan>
    {
        RetailerPlan? WithName(String name);
        List<RetailerPlan> Getplans(string userRole);
    }

}

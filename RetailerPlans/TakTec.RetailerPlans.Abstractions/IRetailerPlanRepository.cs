using Microsoft.VisualBasic.CompilerServices;
using System.Reflection.Metadata;
using System;
using EthioArt.Data.Abstraction;
using TakTec.RetailerPlans.Entities;
using ExtCore.Data.Abstractions;

namespace TakTec.RetailerPlans.Abstractions
{
    public interface IRetailerPlanRepository:IGenericRepository<RetailerPlan>
    {
        RetailerPlan WithCodeorWithName(RetailerPlan retailerPlan);
    }
}

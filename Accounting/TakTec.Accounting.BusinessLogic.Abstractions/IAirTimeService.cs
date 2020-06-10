using System;
using System.Collections.Generic;
using System.Text;
using TakTec.Accounting.Enumerations;
using TakTec.RetailerPlans.Entities;

namespace TakTec.Accounting.BusinessLogic.Abstractions
{
    public interface IAirTimeService
    {
        bool TranserAirTime(String fromUserId, String toUserId, decimal airTime,
            AirTimeUpdateCauseType airTimeUpdateCauseType,
            String airTimeCouseId,
            bool isCredit);

        decimal CalculateAirTime(RetailerPlan plan, decimal amount);
        //decimal CalculateAirTime(double rate, decimal amount);
    }
}

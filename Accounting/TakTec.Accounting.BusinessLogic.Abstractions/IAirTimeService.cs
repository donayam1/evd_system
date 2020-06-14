using System;
using System.Collections.Generic;
using System.Text;
using TakTec.Accounting.Entities;
using TakTec.Accounting.Enumerations;
using TakTec.RetailerPlans.Entities;

namespace TakTec.Accounting.BusinessLogic.Abstractions
{
    public interface IAirTimeService
    {
        bool TranserAirTime(String fromUserId, String toUserId, decimal airTime,
            AirTimeUpdateCauseType airTimeUpdateCauseType,
            String airTimeCauseId);

        bool RemoveAirTimeFromUser(String fromUserId, decimal airTime,
            Enumerations.AirTimeUpdateCauseType airTimeUpdateCauseType,
            String airTimeCauseId
            );
        bool TranserAirTimeFromCurrentUser(String toUserId, decimal airTime,
           Enumerations.AirTimeUpdateCauseType airTimeUpdateCauseType,
           String airTimeCauseId
           );
        decimal CalculateAirTime(RetailerPlan plan, decimal amount);
        bool CreateAirTime(String ownerId);
        AirTime GetCurrentUserAirTime();
        AirTime GetSystemAirTime();
    }
}

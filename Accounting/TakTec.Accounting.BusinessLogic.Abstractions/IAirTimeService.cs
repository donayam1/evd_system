using System;
using System.Collections.Generic;
using System.Text;
using TakTec.Accounting.Enumerations;

namespace TakTec.Accounting.BusinessLogic.Abstractions
{
    public interface IAirTimeService
    {
        bool TranserAirTime(String fromUserId, String toUserId, decimal airTime,
            AirTimeUpdateCauseType airTimeUpdateCauseType,
            String airTimeCouseId,
            bool isCredit);

        decimal CalculateAirTime(double rate, decimal amount);
    }
}

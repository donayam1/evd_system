using EthioArt.Extensions.DateTimeExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using TakTec.Accounting.Entities;
using TakTec.Accounting.ViewModels;

namespace TakTec.Accounting.ObjectMappers
{
    public static class AirTimeMapper
    {
        public static AirTimeModel ToViewModel(this AirTime airTime) {
            AirTimeModel airTimeModel = new AirTimeModel()
            {
                Id = airTime.Id,
                AirTime = airTime.Amount.ToString("0.00"),
                LastUpdatedDate = airTime.LastUpdateDate.ToSharedDateTimeString(),
                ObjectStatus = airTime.IsDeleted ? EthioArt.Data.Enumerations.ObjectStatusEnum.REMOVED :
                  EthioArt.Data.Enumerations.ObjectStatusEnum.UNCHANGED
            };
            return airTimeModel;
        }
    }
}

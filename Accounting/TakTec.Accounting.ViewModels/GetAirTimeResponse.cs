using EthioArt.Backend.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakTec.Accounting.ViewModels
{
    public class GetAirTimeResponse:ResponseBase 
    {
        public AirTimeModel? AirTime { get; set; } = default!;
    }
}

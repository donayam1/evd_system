using EthioArt.Backend.Models;
using EthioArt.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakTec.Accounting.ViewModels
{
    public class AirTimeModel : ISyncedObject
    {
        public String Id { get; set; } = default!;
        public String AirTime { get; set; } = default!;
        public string? LastUpdatedDate { get; set; }
        public ObjectStatusEnum ObjectStatus { get; set; }
    }
}

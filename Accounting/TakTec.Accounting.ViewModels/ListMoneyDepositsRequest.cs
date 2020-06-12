using EthioArt.Backend.Models;
using EthioArt.Backend.Models.Requests;
using EthioArt.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakTec.Accounting.ViewModels
{
    public class ListMoneyDepositsRequest : ISynchronizeItemRequestBase
    {
        public DateTime? FromDate { get ; set ; }
        public bool IsSyncing { get ; set ; }
        public DateTime? ToDate { get ; set ; }
        public bool IsApproved { get; set; }
    }
}

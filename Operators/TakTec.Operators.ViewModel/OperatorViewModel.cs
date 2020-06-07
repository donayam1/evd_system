using System;
using EthioArt.Data.Enumerations;
namespace TakTec.Operators.ViewModel

{
    public class OperatorViewModel 
    {
        public string? Id{get;set;}
        public string Name { get; set; } = default!;
        public string USSDRechargeCode { get; set; } = default!;
        public ObjectStatusEnum Status { get; set; } = ObjectStatusEnum.UNCHANGED;
    }
}

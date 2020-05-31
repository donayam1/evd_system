using EthioArt.Backend.Models.Responses;
using System;
using System.Collections.Generic;
using TakTec.Operators.Entities;

namespace TakTec.Operators.ViewModel
{
    public class OperatorListResposeModel:ResponseBase
    {
        public List<OperatorViewModel> Operators { get; set; } = new List<OperatorViewModel>();
    }
}
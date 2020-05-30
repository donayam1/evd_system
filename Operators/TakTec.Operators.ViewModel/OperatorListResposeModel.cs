using System;
using System.Collections.Generic;
using TakTec.Operators.Entities;

namespace TakTec.Operators.ViewModel
{
    public class OperatorListResposeModel:EthioArt.Backend.Models.Responses.ResponseBase
    {
        public List<OperatorViewModel> operators{get;set;}=default;
    }
}
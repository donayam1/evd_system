using System;
using System.Collections.Generic;
using TakTec.Data.Entities;

namespace TakTec.Operators.ViewModel
{
    public class OperatorListResposeModel:EthioArt.Backend.Models.Responses.ResponseBase
    {
        public List<Operator> operators{get;set;}=default;
    }
}
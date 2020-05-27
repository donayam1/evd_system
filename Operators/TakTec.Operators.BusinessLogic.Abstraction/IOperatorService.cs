using System;
using System.Collections.Generic;
using TakTec.Data.Entities;
namespace TakTec.Operators.BusinessLogic.Abstraction
{
    public interface IOperatorService
    {
        Operator CreateOperator(Operator _operator);
        Operator UpdateOperator(Operator op);
        List <Operator> ListOperator(int pageNo, int NumberOfItemsPerPage);
    }
}

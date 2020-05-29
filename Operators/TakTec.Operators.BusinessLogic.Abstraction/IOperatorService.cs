using System;
using System.Collections.Generic;
using TakTec.Data.Entities;
using TakTec.Operators.ViewModel;

namespace TakTec.Operators.BusinessLogic.Abstraction
{
    public interface IOperatorService
    {
        NewOperatorViewModel CreateOperator(Operator _operator,int  UIid);
        OperatorViewModel UpdateOperator(Operator op);
        List <OperatorViewModel> ListOperator(int pageNo, int NumberOfItemsPerPage);
    }
}

using System;
using System.Collections.Generic;
using TakTec.Operators.Entities;
using TakTec.Operators.ViewModel;

namespace TakTec.Operators.BusinessLogic.Abstraction
{
    public interface IOperatorService
    {
        NewOperatorViewModel? CreateOperator(OperatorViewModel op);
        OperatorViewModel? UpdateOperator(OperatorViewModel op);
        List <OperatorViewModel>? ListOperator(int pageNo, int NumberOfItemsPerPage);
    }
}

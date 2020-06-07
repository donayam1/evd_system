using Microsoft.VisualBasic.CompilerServices;
using System;
using TakTec.Operators.Abstractions;
using TakTec.Operators.Entities;
using System.Linq;
using ExtCore.Data.Abstractions;
using EthioArt.Data.Enumerations;
using EthioArt.Data.Abstraction;
using EthioArt.Data.Entities.Abstraction;
using EthioArt.Data.EntityFramework;
using System.Collections.Generic;
using EthioArt.Filters.Abstraction;
using EthioArt.Data.Entities;
using EthioArt.Sorters.Abstractions;

namespace TakTec.Operators.EntityFramework
{
    public class OperatorRepository : GenericRepositoryBase<Operator>, IOperatorRepository
    {
        public override IQueryable<Operator> LoadNavigationProperties(IQueryable<Operator> items)
        {
            return items;
        }

        public Operator? withUSSDRechargeCode(Operator op)
        {
            var _operator = All().Where(x => 
                                (x.USSDRechargeCode == op. USSDRechargeCode) ||
                                (x.Name == op.Name))
                                .FirstOrDefault();
            return _operator;
        }
        
        
    }
}

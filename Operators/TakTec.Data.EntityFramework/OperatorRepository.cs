using Microsoft.VisualBasic.CompilerServices;
using System;
using TakTec.Data.EntityFramework;
using TakTec.Data.Abstractions;
using System.Linq;
using TakTec.Data.Entities;
using ExtCore.Data.Abstractions;
using EthioArt.Data.Enumerations;
using EthioArt.Data.Abstraction;
using EthioArt.Data.Entities.Abstraction;
using EthioArt.Data.EntityFramework;
using System.Collections.Generic;
using EthioArt.Filters.Abstraction;
using EthioArt.Data.Entities;
using EthioArt.Sorters.Abstractions;

namespace TakTec.Data.EntityFramework
{
    public class OperatorRepository : GenericRepositoryBase<Operator>, IOperatorRepository
    {
        public override IQueryable<Operator> LoadNavigationProperties(IQueryable<Operator> items)
        {
            //TODO implementation
            throw new NotImplementedException();
        }
        
        
    }
}

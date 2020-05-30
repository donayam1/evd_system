using System.Reflection.Metadata;
using System;
using TakTec.Operators.Entities;
using EthioArt.Data.Abstraction;
using EthioArt.Data.Entities.Abstraction;
using ExtCore.Data.Abstractions;
using System.Linq;

namespace TakTec.Operators.Abstractions
{
    public interface IOperatorRepository : IGenericRepository<Operator>
    {
        IQueryable<Operator> LoadNavigationProperties(IQueryable<Operator> items);
    }


}

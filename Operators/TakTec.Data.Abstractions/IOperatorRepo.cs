using System.Reflection.Metadata;
using System;
using TakTec.Data.Entities;
using EthioArt.Data.Abstraction;
using EthioArt.Data.Entities.Abstraction;
using ExtCore.Data.Abstractions;
using System.Linq;

namespace TakTec.Data.Abstractions
{
    public interface IOperatorRepo : IGenericRepository<Operator>
    {
        IQueryable<Operator> LoadNavigationProperties(IQueryable<Operator> items);
    }


}

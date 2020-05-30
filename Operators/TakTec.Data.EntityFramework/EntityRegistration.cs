using TakTec.Data.Entities;
using ExtCore.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;

namespace TakTec.Data.EntityFramework
{
    public class EntityRegistration: IEntityRegistrar
    {
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Operator>(x =>{
                x.HasKey(x =>x.Id);
                x.ToTable(nameof(Operator) + "s");
            });
        }
    }
}
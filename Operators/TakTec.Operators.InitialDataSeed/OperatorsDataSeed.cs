using EthioArt.Data.Enumerations;
using ExtCore.Data.Abstractions;
using IdentityServer4.EntityFramework.DatabaseInit.Abstraction;
using Microsoft.EntityFrameworkCore;
//using IdentityServer4.EntityFramework.StorageContext;
using System;
using System.Collections.Generic;
using TakTec.Operators.Entities;

namespace TakTec.Operators.InitialDataSeed
{

    public static class OperatorData {
        public static List<Operator> operators = new List<Operator>() {
           new Operator("0",ResourceTypes.GROUP,"Ethio Telcome","*805*[PHONE]#"){
              Id = "0"
           }
        };

       
    }

    public class UserDbInitialDataSeed : IInitialDataSeed
    {
        public int Priority { get => 80;  }

        public bool SeedData(IServiceProvider serviceProvider)
        {
            var sc = (DbContext)serviceProvider.GetService(typeof(IStorageContext));
            var usersDbset = sc.Set<Operator>();
            foreach (var v in OperatorData.operators)
            {
                usersDbset.Add(v);
            }
           

            return true;
        }
    }
}

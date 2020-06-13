using ExtCore.Data.Abstractions;
using IdentityServer4.EntityFramework.DatabaseInit.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TakTec.Accounting.Entities;

namespace TakTec.Accounting.InitialDataSeed
{
    public static class BankData {
        public static List<Bank> Banks = new List<Bank>() {
           new Bank("Comercial Bank Of Ethiopia"){ Id="1" },
           new Bank("Awasy Bank"){ Id="2" },
           new Bank("Dashin Bank"){ Id="3" },
           new Bank("Wegagen Bank"){ Id="4" },
           new Bank("Nib Bank"){ Id="5" },

        };       
    }

    public class UserDbInitialDataSeed : IInitialDataSeed
    {
        public int Priority { get => 130;  }

        public bool SeedData(IServiceProvider serviceProvider)
        {
            var sc = (DbContext)serviceProvider.GetService(typeof(IStorageContext));
            var banksDbset = sc.Set<Bank>();
            foreach (var v in BankData.Banks)
            {
                banksDbset.Add(v);
            }
            

            return true;
        }
    }
}

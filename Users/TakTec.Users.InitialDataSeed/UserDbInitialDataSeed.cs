using AspNetIdentity.Data.Entities;
using EthioArt.Data.Enumerations;
using EthioArt.Security.Abstraction;
using ExtCore.Data.Abstractions;
using IdentityServer4.EntityFramework.DatabaseInit.Abstraction;
using Microsoft.EntityFrameworkCore;
//using IdentityServer4.EntityFramework.StorageContext;
using System;
using System.Collections.Generic;
using TakTec.Accounting.Entities;
using TakTec.RetailerPlans.Entities;
using TakTec.RetailerPlans.Enumerations;
using TakTec.Users.Constants;

namespace TakTec.Users.InitialDataSeed
{

    public static class UserData {
        public static List<AspNetUser> Users = new List<AspNetUser>() {
           new AspNetUser(){
              UserName = "SystemAdmin",
              NormalizedUserName = "SYSTEMADMIN",
              Email = "SystemAdmin@gmail.com",
              NormalizedEmail = "SYSTEMADMIN@GMAIL.COM",
              PasswordHash  = "AQAAAAEAACcQAAAAEGX9LoKjpAra5VRDn8ZslrN53yYaPrPI3T0jXVVcQiiCKn12OD3fi8zG04rJeI9+Iw==",
              SecurityStamp = Guid.NewGuid().ToString("D"),
              ConcurrencyStamp = "e6acdd10-fb58-4524-b791-e873b379c9d4",
              Id = "1",
              IsBankAccountCreated = true,
              OwnerType = ResourceTypes.GROUP,
              OwnerId =RoleTypeConstants.RoleNameSupperAdmin,
           }
        };

        public static List<AspNetUserClaim> UserClaims = new List<AspNetUserClaim>() {
            new AspNetUserClaim(){
                UserId = "1",
                ClaimType = "Name",
                ClaimValue = "SystemAdmin"
            },
            new AspNetUserClaim(){
                UserId = "1",
                ClaimType=  "GivenName",
                ClaimValue = "SystemAdmin"
            },
            new AspNetUserClaim(){
                UserId = "1",
                ClaimType=  "EmailVerified",
                ClaimValue = "1"
            },
            new AspNetUserClaim(){
                UserId = "1",
                ClaimType=  "WebSite",
                ClaimValue = "www.taktec.com"
            },
            new AspNetUserClaim(){
                UserId = "1",
                ClaimType=  "permission",
                ClaimValue = "DoEveryThing"
            }
            


        };

        public static List<AspNetRoleType> RoleTypes = new List<AspNetRoleType>()
        {
            new AspNetRoleType(RoleTypeConstants.RoleLevelSystemAdmin, RoleTypeConstants.RoleLevelNameSystemAdmin){ //"SupperAdmin"
                Id = "0"
            },
            new AspNetRoleType(100,"Master Distributor"){ //"SystemAccounts"

                Id = "100"
            },
            new AspNetRoleType(120,"Sub-Distributor"){ //"SystemAccounts"
                Id = "120"
            },

            new AspNetRoleType(RoleTypeConstants.RoleLevelRetailer,RoleTypeConstants.RoleLevelNameRetailer ){ //"Retailer"
                Id = "10000"
            }
        };

        public static List<AspNetRole> Roles = new List<AspNetRole>()
        {
            new AspNetRole("0",RoleTypeConstants.RoleNameSupperAdmin,"1",ResourceTypes.USER){
                Id = "0",
                CreatorUserId = "1"
            }
        };

        public static List<AspNetUserRole> AspNetUserRoles = new List<AspNetUserRole>() {
            new AspNetUserRole(){
                UserId = "1",
                RoleId = "0"
            }
        };

        public static List<RetailerPlan> RetailerPlans = new List<RetailerPlan>() {
            new RetailerPlan(RoleTypeConstants.RoleNameSupperAdmin,"Dummy Plan",
                CommissionRateType.FLAT_COMMISSION,"0"){ 
                Id = "1",
                CommissionRates = new List<CommissionRate>(){ 
                    new CommissionRate("1",0,0)
                }
            }
        };

        public static List<UserPlan> UserPlans = new List<UserPlan>() {
            new UserPlan("1",RoleTypeConstants.RoleNameSupperAdmin)
        };

        public static List<BankAccount> UserAccounts = new List<BankAccount>() {
            new BankAccount("1","0000000000",RoleTypeConstants.RoleNameSupperAdmin)
        };



    }

    public class UserDbInitialDataSeed : IInitialDataSeed
    {
        public int Priority { get => 100;  }

        public bool SeedData(IServiceProvider serviceProvider)
        {
            var sc = (DbContext)serviceProvider.GetService(typeof(IStorageContext));
            var usersDbset = sc.Set<AspNetUser>();
            foreach (var v in UserData.Users)
            {
                usersDbset.Add(v);
            }
            var userClaimsDbset = sc.Set<AspNetUserClaim>();
            foreach (var v in UserData.UserClaims)
            {
                userClaimsDbset.Add(v);
            }

            var roleTypeDbSet = sc.Set<AspNetRoleType>();
            foreach (var v in UserData.RoleTypes)
            {
                roleTypeDbSet.Add(v);
            }

            var rolesDbset = sc.Set<AspNetRole>();
            var airTimeDbset = sc.Set<AirTime>();
            foreach (var v in UserData.Roles)
            {
                rolesDbset.Add(v);
                airTimeDbset.Add(new AirTime(v.Name, 0));
            }

            // That is 
            airTimeDbset.Add(new AirTime(RoleTypeConstants.RoleNameSystem, 0));

            var userRolesDbset = sc.Set<AspNetUserRole>();
            
            foreach (var v in UserData.AspNetUserRoles)
            {
                userRolesDbset.Add(v);
                
            }
            var retailerPlanDbSet = sc.Set<RetailerPlan>();
            foreach (var v in UserData.RetailerPlans) {
                retailerPlanDbSet.Add(v);
            }

            var userPlanDbSet = sc.Set<UserPlan>();
            foreach (var v in UserData.UserPlans)
            {
                userPlanDbSet.Add(v);
            }

            var userAccountDbSet = sc.Set<BankAccount>();
            foreach (var v in UserData.UserAccounts)
            {
                userAccountDbSet.Add(v);
            }

            //TODO initialize user air time data.



            //sc.SaveChanges();

            return true;
        }
    }
}

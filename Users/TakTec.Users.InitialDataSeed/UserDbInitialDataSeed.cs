﻿using AspNetIdentity.Data.Entities;
using EthioArt.Data.Enumerations;
using EthioArt.Security.Abstraction;
using ExtCore.Data.Abstractions;
using IdentityServer4.EntityFramework.DatabaseInit.Abstraction;
using Microsoft.EntityFrameworkCore;
//using IdentityServer4.EntityFramework.StorageContext;
using System;
using System.Collections.Generic;

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
              IsBankAccountCreated = true
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
            },
            new AspNetUserClaim(){
                UserId = "1",
                ClaimType=  "Address",
                ClaimValue = @"{ 'street_address': 'curchel street', 'locality': 'addis ababa', 'postal_code': 12345, 'country': 'Ethiopia' }"
            }


        };

        public static List<AspNetRoleType> RoleTypes = new List<AspNetRoleType>()
        {
            new AspNetRoleType(0,"SupperAdmin"){ 
                Id = "1"
            },
            new AspNetRoleType(100,"SystemAccounts"){
                Id = "100"
            },
            new AspNetRoleType(10000,"Retailer"){
                Id = "10000"
            }
        };

        public static List<AspNetRole> Roles = new List<AspNetRole>()
        {
            new AspNetRole("1","SupperAdmin","1",ResourceTypes.USER){
                Id = "1"
            }
        };

        public static List<AspNetUserRole> AspNetUserRoles = new List<AspNetUserRole>() {
            new AspNetUserRole(){
                UserId = "1",
                RoleId = "1"
            }
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
            foreach (var v in UserData.Roles)
            {
                rolesDbset.Add(v);
            }
            var userRolesDbset = sc.Set<AspNetUserRole>();
            foreach (var v in UserData.AspNetUserRoles)
            {
                userRolesDbset.Add(v);
            }

            //sc.SaveChanges();

            return true;
        }
    }
}

using IdentityServer4.EntityFramework.DatabaseInit.Abstraction;
//using IdentityServer4.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using IdentityServer4.Models;
using System.Linq;
using IdentityServer4.Mappers;
//using IdentityServer4.EntityFramework.StroageContext;
using x = IdentityServer4.EntityFramework.Entities ;
using ExtCore.Data.Abstractions;
using EthioArt.APIs;
using System.Security.Claims;
using EthioArt.Security.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using EthioArt.Data.Enumerations;
using Microsoft.Extensions.Logging;
using EthioArt.UserAccounts.Models;
using EthioArt.UserAccounts.Services.Abstractions;
using Users.BusinessLogic.Abstraction;
using EthioArt.Security.ClaimsCollection;
using EthioArt.Clients.ViewModels;
using IdentityServer4;
using TacTec.APIs;

namespace TakTec.Users.InitialDataSeed
{
    //This are added because the json config binder can not bind with claims that has constractor
    //arguments 
    //MoviesApi
    public class ClientWithXClaim : Client
    {
        public  List<ClaimX> ClaimsX { get; set; } = new List<ClaimX>();
    }

    //public class ClaimX
    //{
    //    public ClaimX()  { 
            
    //    }
    //    public String Type { get; set; } = default!;
    //    public String Value { get; set; } = default!;
    //}


    public static class ApiResourceData
    {
        public static List<x.ApiResource> ApiResources =
            new List<x.ApiResource>()
        {
            new x.ApiResource("",TakApiNames.EVDApi){
                 //Name = ApiNames.MoviesApi,
               
                 DisplayName = "EVD Api",
                 Enabled = true,
                 IsAproved = true,
                 Scopes = new List<x.ApiScope>(){
                      new x.ApiScope(0,TakApiNames.EVDApi){
                           //Name =ApiNames.MoviesApi,
                           ShowInDiscoveryDocument = false,
                      }
                 },                 
                 
                 Secrets = new List<x.ApiSecret>
				 {
				    new x.ApiSecret("secret".Sha256(),0,ResourceTypes.API_RESOURCE){
                        //Value = "secret".Sha256()
                    }
				 }
            },
            new x.ApiResource("", ApiNames.UsersApi){
                 //Name = ApiNames.UsersApi,
                 DisplayName = "Users Api",
                 Enabled = true,
                 IsAproved = true,
                 Scopes = new List<x.ApiScope>(){
                      new x.ApiScope(0, ApiNames.UsersApi){
                           //Name = ApiNames.UsersApi,
                           ShowInDiscoveryDocument = false,
                      }
                 },
                 Secrets = new List<x.ApiSecret>
                 {
                    new x.ApiSecret("secret".Sha256(),0,ResourceTypes.API_RESOURCE){
                        //Value = "secret".Sha256()
                    }
                 }
            },
            new x.ApiResource("", ApiNames.KeysApi){
                 //Name = ApiNames.KeysApi,
                 DisplayName = "Keys Api",
                 Enabled = true,
                 IsAproved = true,
                 Scopes = new List<x.ApiScope>(){
                      new x.ApiScope(0, ApiNames.KeysApi){
                           //Name =  ApiNames.KeysApi,
                           ShowInDiscoveryDocument = true,
                      }
                 },
                 Secrets = new List<x.ApiSecret>
                 {
                    new x.ApiSecret("secret".Sha256(),0,ResourceTypes.API_RESOURCE){
                        //Value = "secret".Sha256()
                    }
                 }
            },
            new x.ApiResource("",ApiNames.BillingApi){
                 //Name = ApiNames.BillingApi,
                 DisplayName = "Billing Api",
                 Enabled = true,
                 IsAproved = true,
                 Scopes = new List<x.ApiScope>(){
                      new x.ApiScope(0,ApiNames.BillingApi){
                           //Name = ApiNames.BillingApi,
                           ShowInDiscoveryDocument = true,
                      }
                 },
                 Secrets = new List<x.ApiSecret>
                 {
                    new x.ApiSecret("secret".Sha256(),0,ResourceTypes.API_RESOURCE){
                        //Value = "secret".Sha256()
                    }
                 }
            },
            new x.ApiResource("",ApiNames.RolesApi){
                 //Name = ApiNames.RolesApi,
                 DisplayName = "Roles Api",
                 Enabled = true,
                 IsAproved = true,
                 Scopes = new List<x.ApiScope>(){
                      new x.ApiScope(0, ApiNames.RolesApi){
                           //Name = ApiNames.RolesApi,
                           ShowInDiscoveryDocument = false,
                      }
                 },
                 Secrets = new List<x.ApiSecret>
                 {
                    new x.ApiSecret("secret".Sha256(),0,ResourceTypes.API_RESOURCE){
                        //Value = "secret".Sha256()
                    }
                 }
            },
            
            
        };
    }

    public static class IdentityResourceData {
        public static List<x.IdentityResource> IdentityResources = 
            new List<x.IdentityResource>()
        {
            new x.IdentityResource(IdentityServerConstants.StandardScopes.OpenId){
                 //Name = IdentityServerConstants.StandardScopes.OpenId,
                 DisplayName = "openid",
                 Enabled = true,
                 Required = true,
                 ShowInDiscoveryDocument = true,
                 IsAproved = true,
                  UserClaims = new List<x.IdentityClaim>(){ 
                    new x.IdentityClaim("openid",0)
                  }
            },
            new x.IdentityResource(IdentityServerConstants.StandardScopes.Profile){
                 //Name = IdentityServerConstants.StandardScopes.Profile,
                 DisplayName = "profile",
                 Enabled = true,
                 Required = false,
                 ShowInDiscoveryDocument = true,
                 IsAproved = true,
                 UserClaims = new List<x.IdentityClaim>(){
                    new x.IdentityClaim("profile",0)
                  }

            },
            new x.IdentityResource(IdentityServerConstants.StandardScopes.Email){
                 //Name = IdentityServerConstants.StandardScopes.Email,
                 DisplayName = "email",
                 Enabled = true,
                 Required = false,
                 ShowInDiscoveryDocument = true,
                 IsAproved = true,
                 UserClaims = new List<x.IdentityClaim>(){
                    new x.IdentityClaim("email",0)
                  }
            }
        };
    }



    public class ISInitialDataSeed : IInitialDataSeed
    {
        public int Priority => 110;

        public bool SeedData(IServiceProvider serviceProvider)
        {
            DbContext? sc = null;
            var logger = serviceProvider.GetService<ILogger<ISInitialDataSeed>>();
            logger.LogInformation("Creating clients");
            IStorageContext stc = serviceProvider.GetService<IStorageContext>();// (typeof(IStorageContext));
            if (stc == null) {
                logger.LogError($"Error resolving {nameof(IStorageContext)}");
                return false;
            }

            if (!(stc is DbContext)) {
                logger.LogError($"the registered IStorageContext is not type of {nameof(IStorageContext)}");
                return false;
            }

            sc = (DbContext)stc;
            var iresDbset = sc.Set<x.IdentityResource>();
            foreach (var v in IdentityResourceData.IdentityResources) {
                iresDbset.Add(v);
            }





            //using (var scope = serviceProvider.CreateScope()) {

                var sp = serviceProvider;// scope.ServiceProvider;

                List<SetUpSystemAccountRequest> accounts = new List<SetUpSystemAccountRequest>();
                ITokenUserService tokenUserService =
                sp.GetService<ITokenUserService>();



                List<Claim> claims = new List<Claim>() { 
                    ClaimsCollection.IsSupperAdminClaim                    
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);
                tokenUserService.User = new ClaimsPrincipal(claimsIdentity);

                var config = sp.GetService<IConfiguration>();//TODO check for null services
                config.GetSection("SystemAccounts").Bind(accounts);

                ISystemAccountSetUpService _systemAccountSetUpService =
                    sp.GetService<ISystemAccountSetUpService>();

                foreach (var v in accounts)
                {
                    try
                    {
                        var res = _systemAccountSetUpService.SetUpNewAccount(v).Result;
                        if (res != null)
                        {
                            logger.LogInformation($"client_id ={res.ClientId}\n" +
                                $"client_secreate{res.ClientSecreate}\n" +
                                $"user_id = {res.UserId}\nuser_name = {res.UserName}\n" +
                                $"role_id = {res.RoleId}\n" +
                                $"role_name = {res.RoleName}\n");
                        }
                    }
                    catch (Exception e) {
                        logger.LogError(e.InnerException,e.Message);
                    }
                }


            //}






            //List<ClientWithXClaim> clients = new List<ClientWithXClaim>();
            //var config = serviceProvider.GetService<IConfiguration>();//TODO check for null services
            //config.GetSection("clients").Bind(clients);
            //var clientsDbset = sc.Set<x.Client>();
            //foreach (var v in clients)  //ClientsData.Clients
            //{
            //    var client = (Client)v;
            //    var clientd = client.ToEntity();

            //    foreach (var cs in clientd.ClientSecrets)
            //    {
            //        cs.Value = cs.Value.Sha256();
            //    }
            //    foreach (var s in v.ClaimsX)
            //    {
            //        x.ClientClaim cl = new x.ClientClaim(clientd.Id, s.Type, s.Value)
            //        {
            //        };
            //        clientd.Claims.Add(cl);
            //    }
            //    clientsDbset.Add(clientd);
            //}



            




        var apiResDbSet = sc.Set<x.ApiResource>();
            foreach (var v in ApiResourceData.ApiResources) {
                apiResDbSet.Add(v);
               

            }
            return true;
        }
    }
}

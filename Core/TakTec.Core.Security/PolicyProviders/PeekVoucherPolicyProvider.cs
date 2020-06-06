using System;
using System.Collections.Generic;
using System.Text;
using EthioArt.Security.Abstraction;
using Microsoft.AspNetCore.Authorization;
using TakTec.Users.Constants;

namespace TakTec.Core.Security.PolicyProviders
{
    public class PeekVoucherBatchPolicyProvider :
                EthioArt.Security.Abstraction.IAuthorizationPolicyProvider
    {
        public string Name => Policies.PeekAVoucherPolicy;
        /// <summary>
        /// User is memeber of supper admin group and has upload voucher permission 
        /// or user has DoEverything Claim and belongs to supper admin group.
        /// </summary>
        /// <returns></returns>
        public AuthorizationPolicy GetAuthorizationPolicy()
        {
            AuthorizationPolicyBuilder authorizationPolicyBuilder = new AuthorizationPolicyBuilder();
            authorizationPolicyBuilder.RequireAssertion(context =>
            {
                return
                context.User.HasClaim(EthioArtClaimTypes.Role, RoleTypeConstants.RoleNameSupperAdmin) &&
                (context.User.HasClaim(EthioArtClaimTypes.Permission, Permissions.PeekAVoucherPermission) ||
                context.User.HasClaim(EthioArtClaimTypes.Permission, EthioArtPermissions.DoEveryThing)) 
                ;
            });

            return authorizationPolicyBuilder.Build();
        }
    }
}

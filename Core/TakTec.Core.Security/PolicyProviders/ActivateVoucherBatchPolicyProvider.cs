using System;
using System.Collections.Generic;
using System.Text;
using EthioArt.Security.Abstraction;
using Microsoft.AspNetCore.Authorization;

namespace TakTec.Core.Security.PolicyProviders
{
    public class ActivateVoucherBatchPolicyProvider :
                EthioArt.Security.Abstraction.IAuthorizationPolicyProvider

    {
        public string Name => Policies.ActivateVoucherPolicy;

        public AuthorizationPolicy GetAuthorizationPolicy()
        {
            AuthorizationPolicyBuilder authorizationPolicyBuilder = new AuthorizationPolicyBuilder();
            authorizationPolicyBuilder.RequireAssertion(context =>
            {
                return context.User.HasClaim(EthioArtClaimTypes.Permission, Permissions.ActivateVoucherBatch) ||
                context.User.HasClaim(EthioArtClaimTypes.Permission, EthioArtPermissions.DoEveryThing);
            });

            return authorizationPolicyBuilder.Build();
        }
    }
}

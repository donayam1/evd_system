using System;
using System.Collections.Generic;
using System.Text;
using EthioArt.Security.Abstraction;
using Microsoft.AspNetCore.Authorization;

namespace TakTec.Core.Security.PolicyProviders
{
    public class ManageKeysPolicyProvider :
                EthioArt.Security.Abstraction.IAuthorizationPolicyProvider

    {
        public string Name => Policies.ManageKeysPolicy;

        public AuthorizationPolicy GetAuthorizationPolicy()
        {
            AuthorizationPolicyBuilder authorizationPolicyBuilder = new AuthorizationPolicyBuilder();
            authorizationPolicyBuilder.RequireAssertion(context =>
            {
                return context.User.HasClaim(EthioArtClaimTypes.Permission, Permissions.ManageKeys) ||
                context.User.HasClaim(EthioArtClaimTypes.Permission, EthioArtPermissions.DoEveryThing);
            });

            return authorizationPolicyBuilder.Build();
        }
    }
}

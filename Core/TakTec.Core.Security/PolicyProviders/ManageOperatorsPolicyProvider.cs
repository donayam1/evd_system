using System;
using System.Collections.Generic;
using System.Text;
using EthioArt.Security.Abstraction;
using Microsoft.AspNetCore.Authorization;

namespace TakTec.Core.Security.PolicyProviders
{
    public class ManageOperatorsPolicyProvider :
                EthioArt.Security.Abstraction.IAuthorizationPolicyProvider

    {
        public string Name => Policies.ManageOperatorsPolicy;

        public AuthorizationPolicy GetAuthorizationPolicy()
        {
            AuthorizationPolicyBuilder authorizationPolicyBuilder = new AuthorizationPolicyBuilder();
            authorizationPolicyBuilder.RequireAssertion(context =>
            {
                return context.User.HasClaim(EthioArtClaimTypes.Permission, Permissions.ManageOperators) ||
                context.User.HasClaim(EthioArtClaimTypes.Permission, EthioArtPermissions.DoEveryThing);
            });

            return authorizationPolicyBuilder.Build();
        }
    }
}

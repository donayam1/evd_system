using System;
using System.Collections.Generic;
using System.Text;
using EthioArt.Security.Abstraction;
using Microsoft.AspNetCore.Authorization;

namespace TakTec.Core.Security.PolicyProviders
{
    public class UploadVoucherPolicyProvider :
                EthioArt.Security.Abstraction.IAuthorizationPolicyProvider

    {
        public string Name => Policies.UploadVoucherPolicy;

        public AuthorizationPolicy GetAuthorizationPolicy()
        {
            AuthorizationPolicyBuilder authorizationPolicyBuilder = new AuthorizationPolicyBuilder();
            authorizationPolicyBuilder.RequireAssertion(context =>
            {
                return context.User.HasClaim(EthioArtClaimTypes.Permission, Permissions.UploadVoucher) ||
                context.User.HasClaim(EthioArtClaimTypes.Permission, EthioArtPermissions.DoEveryThing);
            });

            return authorizationPolicyBuilder.Build();
        }
    }
}

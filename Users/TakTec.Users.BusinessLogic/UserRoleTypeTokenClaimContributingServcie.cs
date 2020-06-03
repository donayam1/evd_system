using AspNetIdentity.Data.Entities;
using EthioArt.Security.Abstraction;
using EthioArt.UserAccounts.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Roles.BusinessLogic.Abstraction;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TakTec.Users.BusinessLogic
{
    public class UserRoleTypeTokenClaimContributingServcie :
    IUserTokenClaimContributingServcie
    {
        private readonly UserManager<AspNetUser> _userManager;
        //private readonly IUserPhoneNumberManger _userPhoneNumberManger;
        private readonly IRoleService _roleService;

        public UserRoleTypeTokenClaimContributingServcie(UserManager<AspNetUser> userManager,
           IRoleService roleService
           )
        {
            this._userManager = userManager ??
                throw new ArgumentNullException(nameof(UserManager<AspNetUser>));
            _roleService = roleService ??
                throw new ArgumentNullException(nameof(IRoleService));
        }

        public async Task<List<Claim>> GetClaimsToAddToToken(String userId)
        {
            List<Claim> claims = new List<Claim>();

            var user = await _userManager.FindByIdAsync(userId);
            var role = _roleService.GetUserRole(userId);
            
            var claim = new Claim(EthioArtClaimTypes.RoleType, role.AspNetRoleType.TypeName);
            claims.Add(claim);



            return claims;
        }
    }
}

using AspNetIdentity.Data.Entities;
using System;

using TakTec.Users.ViewModels;
using System.Linq;
using EthioArt.Security.Abstraction;
using System.Collections.Generic;

namespace TakTec.Users.ObjectMappers
{
    public static class UsersMapper
    {
        public static ListUserModel ToViewModel(this AspNetUserRole userRole)
        {
            String firstName = userRole.AspNetUser.
                AspNetUserClaims.Where(x => (x.ClaimType == EthioArtClaimTypes.FirstName) ||
                (x.ClaimType == EthioArtClaimTypes.Name)).FirstOrDefault()?.ClaimValue??"";

            String lastName = userRole.AspNetUser.
                AspNetUserClaims.Where(x => (x.ClaimType == EthioArtClaimTypes.LastName))
                .FirstOrDefault()?.ClaimValue ?? "";
            String middleName = userRole.AspNetUser.
                AspNetUserClaims.Where(x => (x.ClaimType == EthioArtClaimTypes.MiddleName))
                .FirstOrDefault()?.ClaimValue ?? "";

            ListUserModel res = new ListUserModel()
            {
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                Id = userRole.UserId,
                UserName = userRole.AspNetUser.UserName,
                Email = userRole.AspNetUser.Email,
                RoleTypeId = userRole.AspNetRole.RoleTypeId,
                GroupTypeName = userRole.AspNetRole.AspNetRoleType.TypeName,
                GroupName = userRole.AspNetRole.Name
            };

            return res;
        }

        public static List<ListUserModel> ToViewModel(this List<AspNetUserRole> userRoles) {
            return userRoles.Select(x => x.ToViewModel()).ToList();
        }

    }
}

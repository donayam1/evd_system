using AspNetIdentity.Data.Entities;
using EthioArt.Backend.Models.Requests;
using EthioArt.UserAccounts.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TakTec.Users.ViewModels;

namespace TakTec.Users.BusinessLogic.Abstractions
{
    public interface IEVDUserService
    {
        Task<RegisterUserResult?> RegisterUserAsync(NewUserModel request);
        List<ListUserModel> ListUsers(PagedItemRequestBase request);
    }

}

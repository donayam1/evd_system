using EthioArt.UserAccounts.Models;
using System;
using System.Threading.Tasks;
using TakTec.Users.ViewModels;

namespace TakTec.Users.BusinessLogic.Abstractions
{
    public interface IEVDUserRegistrationService
    {
        Task<RegisterUserResult?> RegisterUserAsync(NewUserModel request);
    }

}

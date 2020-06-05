using EthioArt.Backend.Models.Responses;
using EthioArt.UserAccounts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakTec.Users.ViewModels
{
    public class NewUserResponse:ResponseBase 
    {
        public RegisterUserResult? Result { get; set; } = default!;
    }
}

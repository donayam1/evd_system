using EthioArt.Backend.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakTec.Users.ViewModels
{
    public class ListUsersResponse:ResponseBase 
    {
        public List<ListUserModel> Users { get; set; } 
            = new List<ListUserModel>();
    }
}

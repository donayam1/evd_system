using System;
using System.Collections.Generic;
using System.Text;

namespace TakTec.Users.ViewModels
{
    public class ListUserModel: UserModel
    {
        public String GroupName { get; set; } = default!;
        public String GroupTypeName { get;set; } = default!;

    }
}

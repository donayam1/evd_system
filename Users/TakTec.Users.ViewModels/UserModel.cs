using EthioArt.Data.Enumerations;
using System;

namespace TakTec.Users.ViewModels
{
    public class UserModel
    {
        public String? Id { get; set; }// String  Temporary id
        public String UserName { get; set; } = default!;//   String
        public String Email { get; set; } = default!; //  String
        public String PhoneNumber { get; set; } = default!; // String
        public String FirstName { get; set; } = default!; // String
        public String MiddleName { get; set; } = default!; // String
        public String LastName { get; set; } = default!;//   String
       


    }
}

using EthioArt.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakTec.Users.ViewModels
{
    public class NewUserModel: UserModel
    {
        //public String RankId { get; set; } = default!;
        //(Group)  String The group id :- if the selected group is the same as the current user then this user will be made the same us the current user and the plan id will be ignored
        public String PlanId { get; set; } = default!; // String The distributor plan id :- the plan id from the available plans
        public ObjectStatusEnum ObjectStatus { get; set; } // Type New
        //public List<String> Permission { get; set; } = new List<string>();
    }
}

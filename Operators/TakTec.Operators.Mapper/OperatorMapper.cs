using System.Linq;
using System.Collections.Generic;
using System;
using TakTec.Operators.Entities;
using TakTec.Operators.ViewModel;
using EthioArt.Data.Entities;
using EthioArt.Data.Enumerations;

namespace TakTec.Operators.Mapper
{
    public static class OperatorMapper
    {
        public static OperatorViewModel ToViewModel(this Operator op)
        {
            var OpviewModel = new OperatorViewModel();
            OpviewModel.Name = op.Name;
            OpviewModel.USSDRechargeCode = op.USSDRechargeCode;
            OpviewModel.Id = op.Id;
            return OpviewModel;
        }

        public static Operator ToDomainModel(this OperatorViewModel opVM)
        {
            var OPModel = new Operator("", ResourceTypes.GROUP, opVM.Name, opVM.USSDRechargeCode);
            //OPModel.Id = opVM.Id;
            return OPModel;
        }
        public static NewOperatorViewModel ToNewOperatorViewModel(this Operator op, String UI_ID)
        {
            NewOperatorViewModel OpviewModel = new NewOperatorViewModel();
            OpviewModel.Name = op.Name;
            OpviewModel.USSDRechargeCode = op.USSDRechargeCode;
            OpviewModel.UI_Id = UI_ID;
            OpviewModel.Id = op.Id;
            return OpviewModel;
        }

        public static List<OperatorViewModel> ToViewModelList(this List<Operator> Operatorlist)
        {
            var items = Operatorlist.Select(x => x.ToViewModel()).ToList();
            return items;
        }
    }
}
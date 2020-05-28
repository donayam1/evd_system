using System.Collections.Generic;
using System;
using TakTec.Data.Entities;
using TakTec.Operators.ViewModel;
using EthioArt.Data.Entities;
using EthioArt.Data.Enumerations;

namespace TakTec.Operators.Mapper
{
    public static class OperatorMapper
    {
        public static OperatorViewModel ToViewModel(Operator op,Status status){
            var OpviewModel = new OperatorViewModel(op.OwnerId,op.OwnerType,op.Name,op.USSDRechargeCode);
            OpviewModel.Status = status;
            return OpviewModel;
        }

       

        public static Operator ToDomainModel (OperatorViewModel opVM){
            string OwnerID = opVM.OwnerId;
            var OPModel = new Operator(OwnerID,opVM.OwnerType,opVM.Name,opVM.USSDRechargeCode);
            
            return OPModel;
        }
        public static NewOperatorViewModel ToNewOperatorViewModel(Operator op,int UI_ID){
            NewOperatorViewModel OpviewModel = new NewOperatorViewModel(op.OwnerId,op.OwnerType,op.Name,op.USSDRechargeCode);
            OpviewModel.Status = Status.NEW;
            OpviewModel.UI_Id = UI_ID;
            return OpviewModel;
        }
    }
}
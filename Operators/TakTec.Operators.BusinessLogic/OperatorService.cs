using System.Linq;
using System;
using System.Collections.Generic;
using TakTec.Operators.Abstractions;
using TakTec.Operators.Entities;
using EthioArt.Data.Enumerations;
using Messages.Logging.Extensions;
using TakTec.Operators.BusinessLogic.Abstraction;
using ExtCore.Data.Abstractions;
using TakTec.Operators.ViewModel;
using TakTec.Operators.Mapper;
using EthioArt.Filters.Abstraction;
using EthioArt.Data.Entities;
using EthioArt.Sorters.Abstractions;
using Microsoft.Extensions.Logging;

namespace TakTec.Operators.BusinessLogic
{
    public class OperatorService : IOperatorService
    {
        
        private readonly IOperatorRepository _operatorRepository;
        private readonly ILogger<IOperatorService> _logger;
        private readonly IStorage _storage;

        public OperatorService(IStorage storage, ILogger<IOperatorService> logger)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            _operatorRepository = _storage.GetRepository<IOperatorRepository>() ??
                                throw new ArgumentNullException(nameof(IOperatorService));
            _logger= logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public OperatorViewModel? CreateorUpdateOperator(OperatorViewModel operatorVM)
        {
            Operator _operator = operatorVM.ToDomainModel();
            // validation
            if(!isValidOperator(_operator,operatorVM.Status))
            {
                _logger.AddUserError("Invalid Request");
                return null;
            }

            Operator? op;

            switch(operatorVM.Status)
            {
                case ObjectStatusEnum.NEW:
                    op = CreateOperator(_operator);
                    break;
                case ObjectStatusEnum.EDITTED:
                    op = UpdateOperator(_operator);
                    break;
                case ObjectStatusEnum.REMOVED:
                    op = RemoveOperator(_operator);
                    break;
                default:
                    return operatorVM;
            }

            if(op != null)
            {
                try
                {
                    _storage.Save();
                }
                catch(Exception e)
                {
                    _logger.LogError(e.InnerException,e.Message);
                    _logger.AddUserError("Unknown error. Please contact administrator");
                    return null;
                }
            }
            var oper = op.ToViewModel();

            return oper;

        }


        private bool isValidOperator(Operator op,ObjectStatusEnum Status)
        {
            Operator? _operator = _operatorRepository.withUSSDRechargeCode(op);
            if(Status != ObjectStatusEnum.NEW)
            {
                bool exists = _operatorRepository.Exists(op.Id);
                if(!exists)
                {
                    _logger.AddUserError("Operator does not exist!");
                    return false;
                }
                if(_operator != null)
                {
                    _logger.AddUserError("Operator with USSD recharge code"+op.USSDRechargeCode+"or Name "+op.Name+"aleady exists");
                    return false;
                }
            }
            else if(Status == ObjectStatusEnum.NEW)
            {
                if(_operator!=null)
                {
                     _logger.AddUserError("Operator with USSD recharge code"+op.USSDRechargeCode+"or Name "+op.Name+"aleady exists");
                    return false;
                }
            }
            return true;
        }


        private Operator CreateOperator(Operator op)
        {
            _operatorRepository.Create(op);
            return op;
        }



        private Operator UpdateOperator(Operator op)
        {
            var _operator = _operatorRepository.WithKey(op.Id);
            _operator.Name = op.Name;
            _operator.USSDRechargeCode = op.USSDRechargeCode;
            _operatorRepository.Edit(_operator);
            return _operator;
        }



        public List<OperatorViewModel>? ListOperator(int pageNo, int NumberOfItemsPerPage)
        {
            var items = _operatorRepository.GetCustomFilters(pageNo,NumberOfItemsPerPage).Items.ToList();//.GetCustomFilters<Operator>();
            if(items ==null){
                _logger.AddUserError("There is no operator in database!");
                return null;
            }
            else{
                string msg = "There are " + items.Count + " operators";
                _logger.AddUserMesage(msg);
                return OperatorMapper.ToViewModelList(items);
            }
        }


        public Operator? RemoveOperator (Operator op)
        {
            return null;
        }
    }
}

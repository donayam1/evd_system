using System.Linq;
using System;
using System.Collections.Generic;
using TakTec.Data.Abstractions;
using TakTec.Data.Entities;
using EthioArt.Data.Enumerations;
using Messages.Logging.Extensions;
using Microsoft.Extensions.Logging;
using TakTec.Operators.BusinessLogic.Abstraction;
using ExtCore.Data.Abstractions;

namespace TakTec.Operators.BusinessLogic
{
    public class OperatorService : IOperatorService
    {
        
        private readonly IOperatorRepo _operatorRepository;
        private readonly ILogger<IOperatorService> _logger;

        public OperatorService(IStorage storage, ILogger<Operator> Logger){
            _operatorRepository = storage.GetRepository<IOperatorRepo>();
            _logger= (ILogger<IOperatorService>)Logger;
        }
        public Operator CreateOperator(Operator _operator)
        {
            bool exists= _operatorRepository.Exists(_operator.Id);
            if(exists){
                _logger.AddUserError("Operator already exists");
                return null;
            }
            else{
                // TODO ViewModel to DomainModel and update OperatorViewModel.Status
                _operatorRepository.Create(_operator);
                _logger.AddUserError("Operator Created successfully!");
                return _operator;// return viewmodel
            }
            
        }

        public List<Operator> ListOperator(int pageNo, int NumberOfItemsPerPage)
        {
            var items = _operatorRepository.All()
                        .Skip(NumberOfItemsPerPage * (pageNo - 1))
                        .Take(NumberOfItemsPerPage)
                        .ToList();
            
            return items;
        }

        public Operator UpdateOperator(Operator op)
        {

            bool exists= _operatorRepository.Exists(op.Id);
            if(!exists){
                _logger.AddUserError("Operator does not exist!");
                return null;
            }
            else{
                // TODO ViewModel to DomainModel and update OperatorViewModel.Status
                _operatorRepository.Edit(op);
                _logger.AddUserError("Operator Updated successfully!");
                return op;// return viewmodel
            }
        }
    }
}

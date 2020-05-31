﻿using System.Linq;
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
        public OperatorService(IStorage storage, ILogger<IOperatorService> Logger){
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            _operatorRepository = _storage.GetRepository<IOperatorRepository>() ??
                throw new ArgumentNullException(nameof(IOperatorService));
            _logger= Logger ??
                throw new ArgumentNullException(nameof(ILogger<IOperatorService>));
        }
        public NewOperatorViewModel? CreateOperator(OperatorViewModel _operator)
        {
            String UiId = _operator.Id;
            //bool exists= _operatorRepository.Exists(_operator.Id);
            //if(exists){
            //    _logger.AddUserError("Operator already exists");
            //    return null;
            //}
            //else{

            var oper = _operator.ToDomainModel();
            _operatorRepository.Create(oper);
            _storage.Save();
            _logger.AddUserMesage("Operator Created successfully!");
            var newOPViewModel = oper.ToNewOperatorViewModel(UiId);// OperatorMapper.ToNewOperatorViewModel(_operator, UiId);
            return newOPViewModel;// return viewmodel

            //}
            
        }

        public List<OperatorViewModel>? ListOperator(int pageNo, int NumberOfItemsPerPage)
        {
            // var items = _operatorRepository.All()
            //             .Skip(NumberOfItemsPerPage * (pageNo - 1))
            //             .Take(NumberOfItemsPerPage)
            //             .ToList();
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

        public OperatorViewModel? UpdateOperator(OperatorViewModel op)
        {

            bool exists= _operatorRepository.Exists(op.Id);
            if(!exists){
                _logger.AddUserError("Operator does not exist!");
                return null;
            }
            else{
                var oper = op.ToDomainModel();
                _operatorRepository.Edit(op.ToDomainModel());
                _logger.AddUserMesage("Operator Updated successfully!");
                var opVM = oper.ToViewModel();// OperatorMapper.ToViewModel(oper.);
                return opVM;// return viewmodel
            }
        }
    }
}

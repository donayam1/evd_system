﻿using System.Threading;
using System;
using System.Threading.Tasks;
using EthioArt.Backend.Models;
using Messages.BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Mvc;
using TakTec.Operators.Entities;
using TakTec.Operators.BusinessLogic;
using TakTec.Operators.BusinessLogic.Abstraction;
using Messages.Logging.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Messages.Models;
using Messages.BusinessLogic;
using System.Linq;
using TakTec.Operators.ViewModel;
using EthioArt.Backend.Models.Requests; 

namespace TakTec.Operators.Backend
{
    
    public class OperatorController:ControllersBase 
    {
        
       // private readonly IUserMessageLogges _userMessageLogges;
       private readonly IOperatorService _operatorService;
        
        public OperatorController(IUserMessageLogges userMessageLogges,IOperatorService operatorService):
            base(userMessageLogges)
        { 
            _operatorService = operatorService;
          //  _userMessageLogges = userMessageLogges;
        }

        [HttpGet]
        public  IActionResult ListOperators([FromQuery]PagedItemRequestBase  page) {
            OperatorListResposeModel operatorList= new OperatorListResposeModel();
            if (ModelState.IsValid) {
                var items = _operatorService.ListOperator(page.Page,page.ItemsPerPage);
                if(items == null){
                   // operatorList.Messages = _userMessageLogges.UserErrorMessages;
                    operatorList.Status = false;
                }
                //operatorList.Messages=_userMessageLogges.UserMessages;
                operatorList.Operators=items;
                SendResult(operatorList);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Operator op)
        {
            NewOperatorResponseViewModel resp = new NewOperatorResponseViewModel();
            
            if (ModelState.IsValid)
            {
                var newOperator =  _operatorService.CreateOperator(op);
                if(newOperator == null){
                    resp.Status = false;
                    //resp.Messages = _userMessageLogges.UserErrorMessages;
                }
                //resp.Messages=_userMessageLogges.UserMessages;
                resp.newOperatorViewModel = newOperator;
                SendResult(resp);
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Update([FromBody] Operator op)
        {
            OperatorResponseModel resp = new OperatorResponseModel();

            if(ModelState.IsValid)
            {
                var UpdatedOp = _operatorService.UpdateOperator(op);
                if(UpdatedOp == null){
                    resp.Status = false;
                   // resp.Messages=_userMessageLogges.UserErrorMessages;
                }
               // resp.Messages=_userMessageLogges.UserMessages;
                resp.Operator = UpdatedOp;
                SendResult(resp);
            }
            return BadRequest(ModelState);
        }

        


    }
}

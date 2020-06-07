using System.Threading;
using System;
using System.Threading.Tasks;
using EthioArt.Backend.Models;
using Messages.BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Mvc;
using TakTec.Operators.Entities;
using TakTec.Operators.BusinessLogic;
using TakTec.Operators.BusinessLogic.Abstraction;
using TakTec.Operators.ViewModel;
using EthioArt.Backend.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using TakTec.Core.Security;

namespace TakTec.Operators.Backend
{
    [Route("api/operators/[controller]")]
    [Authorize(AuthenticationSchemes = EVDAuthenticationNames.EVDAuthenticationName,
        Policy = TakTec.Core.Security.Policies.ManageOperatorsPolicy)]
    public class OperatorController:ControllersBase 
    {
        
       // private readonly IUserMessageLogges _userMessageLogges;
       private readonly IOperatorService _operatorService;
        
        public OperatorController(IUserMessageLogges userMessageLogges,IOperatorService operatorService):
            base(userMessageLogges)
        { 
            _operatorService = operatorService ?? 
                throw new ArgumentNullException(nameof(IOperatorService));
          //  _userMessageLogges = userMessageLogges;
        }

        [HttpGet(template:"list")]
        public  IActionResult ListOperators([FromQuery]PagedItemRequestBase  page) {
            OperatorListResposeModel operatorList= new OperatorListResposeModel();
            if (ModelState.IsValid) {
                var items = _operatorService.ListOperator(page.Page,page.ItemsPerPage);
                if (items == null)
                {
                    // operatorList.Messages = _userMessageLogges.UserErrorMessages;
                    operatorList.Status = false;
                }
                else {
                    operatorList.Status = true;
                    operatorList.Operators = items;
                }
                //operatorList.Messages=_userMessageLogges.UserMessages;
                
                return SendResult(operatorList);
            }
            return BadRequest(ModelState);
        }

        [HttpPost(template:"create")]
        public IActionResult Create([FromBody] OperatorViewModel op)
        {
            NewOperatorResponseViewModel resp = new NewOperatorResponseViewModel();
            
            if (ModelState.IsValid)
            {
                var newOperator =  _operatorService.CreateorUpdateOperator(op);
                if (newOperator == null)
                {
                    resp.Status = false;
                }
                else {
                    resp.Status = true;
                    resp.NewOperatorViewModel = (NewOperatorViewModel)newOperator;
                }

                return SendResult(resp);
            }
            return BadRequest(ModelState);
        }


        [HttpPost(template:"update")]
        public IActionResult Update([FromBody] OperatorViewModel op)
        {
            OperatorResponseModel resp = new OperatorResponseModel();

            if(ModelState.IsValid)
            {
                var UpdatedOp = _operatorService.CreateorUpdateOperator(op);
                if (UpdatedOp == null)
                {
                    resp.Status = false;
                }
                else
                {
                    resp.Status = true;
                    resp.Operator = UpdatedOp;
                }
                
                return SendResult(resp);
            }
            return BadRequest(ModelState);
        }

        


    }
}

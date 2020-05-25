using System;
using System.Threading.Tasks;
using EthioArt.Backend.Models;
using Messages.BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace TakTec.Operators.Backend
{
    public class OperatorController:ControllersBase  
    {
        public OperatorController(IUserMessageLogges userMessageLogges):
            base(userMessageLogges)
        { 
        }

        //[HttpGet]
        //public  IActionResult ListOperators([FromBody] String r) {
        //    if (ModelState.IsValid) {
                
        //        SendResult(res);
        //    }
        //    return BadRequest(ModelState);
        //}

        //[HttpPost]
        //public IActionResult Creoteupradfa([FromBody] String r)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        SendResult(res);
        //    }
        //    return BadRequest(ModelState);
        //}


    }
}

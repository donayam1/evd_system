using EthioArt.Backend.Models;
using Messages.BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Vouchers.ViewModels;

namespace Vouchers.Backend.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/keys/[controller]")]
    public class KeysController: FileUploadControllerBase
    {
        public KeysController(IUserMessageLogges logs,
            IWebHostEnvironment hostingEnvironment) :
           base(logs, hostingEnvironment)
        { 
        }

        [HttpPost, DisableRequestSizeLimit]
        public ActionResult Upload()
        {
            UploadedFile file= this.UploadTheFile();
            if (file.Status == true)
            {

            }
            else { 
            
            }
            return Ok(true);           
        }
    }
}

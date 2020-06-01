using EthioArt.Backend.Models;
using Messages.BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TakTec.Core.Security;
using Vouchers.ViewModels;

namespace Vouchers.Backend.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/keys/[controller]")]
    [Authorize(AuthenticationSchemes = EVDAuthenticationNames.EVDAuthenticationName,
        Policy = Policies.ManageKeysPolicy)]
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

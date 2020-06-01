using Messages.BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vouchers.BusinessLogic.Abstractions;
using System.IO;
using System.Net.Http.Headers;
using Vouchers.ViewModels;

namespace Vouchers.Backend.Controllers
{
   

    public abstract class FileUploadControllerBase : VoucherControllersBase
    {
        IWebHostEnvironment _hostingEnvironment;

        public FileUploadControllerBase(IUserMessageLogges logs,
            IWebHostEnvironment hostingEnvironment) :
            base(logs)
        {
            _hostingEnvironment = hostingEnvironment;

        }


   
        public UploadedFile UploadTheFile()
        {
            try
            {
                var file = Request.Form.Files[0];
                string folderName = "Upload";
                string webRootPath = _hostingEnvironment.ContentRootPath;
                string newPath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                String? fullPath = null;
                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                return new UploadedFile(true, fullPath);
            }
            catch (System.Exception ex)
            {
                
                return new UploadedFile(false, null);
            }
        }

    }
}

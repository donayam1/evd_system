using System;

namespace Vouchers.ViewModels
{
    public class UploadedFile
    {
        public UploadedFile(bool status, String? fullPath)
        {
            this.FullPath = fullPath;
            this.Status = status;
        }
        public String? FullPath { get; set; }
        public bool Status { get; set; }
    }
}

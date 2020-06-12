using EthioArt.Backend.Models.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TakTec.Accounting.ViewModels
{
    public class ListBankAccountsRequest:PagedItemRequestBase 
    {
        [Required]
        public String UserId { get; set; } = default!;
    }
}

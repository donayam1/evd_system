﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TakTec.PurchaseOrders.ViewModels
{
    public class NewPurchaseOrderResult: NewPurchaseOrderRequest
    {
        public String? UI_Id { get; set; } = default!;
    }
}
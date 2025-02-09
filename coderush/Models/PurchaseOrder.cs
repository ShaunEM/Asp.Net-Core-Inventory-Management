﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace coderush.Models
{
    public class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }
        [Display(Name = "Order Number")]
        public string PurchaseOrderName { get; set; }

        [Display(Name = "BranchStore")]
        public int BranchStoreId { get; set; }
        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset DeliveryDate { get; set; }

        [Display(Name = "Purchase Type")]
        public int PurchaseTypeId { get; set; }
        public string Remarks { get; set; }
        public double Total { get; set; }
        public List<PurchaseOrderLine> PurchaseOrderLines { get; set; } = new List<PurchaseOrderLine>();
        

    }
}

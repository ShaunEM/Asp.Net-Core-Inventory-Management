﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coderush.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        [Display(Name = "Bill / Invoice Number")]
        public string BillName { get; set; }
        [Display(Name = "GRN")]
        public int GoodsReceivedNoteId { get; set; }
        [Display(Name = "Supplier Delivery Order #")]
        public string SupplierDONumber { get; set; }
        [Display(Name = "Supplier Bill / Invoice #")]
        public string SupplierInvoiceNumber { get; set; }
        [Display(Name = "Bill Date")]
        public DateTimeOffset BillDate { get; set; }
        [Display(Name = "Bill Due Date")]
        public DateTimeOffset BillDueDate { get; set; }
        [Display(Name = "Bill Type")]
        public int BillTypeId { get; set; }
    }
}

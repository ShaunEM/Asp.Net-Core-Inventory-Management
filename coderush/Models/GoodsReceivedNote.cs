using System;
using System.ComponentModel.DataAnnotations;

namespace coderush.Models
{
    public class GoodsReceivedNote
    {
        public int GoodsReceivedNoteId { get; set; }
        [Display(Name = "GRN Number")]
        public string GoodsReceivedNoteName { get; set; }
        [Display(Name = "Purchase Order")]
        public int PurchaseOrderId { get; set; }
        [Display(Name = "GRN Date")]
        public DateTimeOffset GRNDate { get; set; }
        [Display(Name = "Supplier Delivery Order #")]
        public string SupplierDONumber { get; set; }
        [Display(Name = "Supplier Bill / Invoice #")]
        public string SupplierInvoiceNumber { get; set; }
        [Display(Name = "BranchArea")]
        public int BranchStoreId { get; set; }
    }
}

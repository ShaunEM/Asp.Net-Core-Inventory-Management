using System.ComponentModel.DataAnnotations;

namespace coderush.Models
{
    public class PurchaseOrderLine
    {
        public int PurchaseOrderLineId { get; set; }
        [Display(Name = "Purchase Order")]
        public int PurchaseOrderId { get; set; }
        //[Display(Name = "Purchase Order")]
        //public PurchaseOrder PurchaseOrder { get; set; }
        [Display(Name = "Part")]
        public int PartId { get; set; }
        public string Description { get; set; }
        public int QTY { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
    }
}

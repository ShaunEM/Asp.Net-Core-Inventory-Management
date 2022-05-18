using System.ComponentModel.DataAnnotations;

namespace coderush.Models
{
    public class PurchaseOrderLine
    {
        public int PurchaseOrderLineId { get; set; }
        [Display(Name = "Purchase Order")]
        public int PurchaseOrderId { get; set; }

        [Display(Name = "Item")]
        public int StockId { get; set; }
        public string Description { get; set; }
        public int QTY { get; set; }
        public double UnitPrice { get; set; }
        public double Total { get; set; }
    }
}

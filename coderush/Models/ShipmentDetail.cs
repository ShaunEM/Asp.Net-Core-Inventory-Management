using System.ComponentModel.DataAnnotations;

namespace coderush.Models
{
    public class ShipmentDetail
    {
        public int ShipmentDetailId { get; set; }

        [Display(Name = "Item")]
        public int StockId { get; set; }
        public int QTY { get; set; }
        public double UnitPrice { get; set; }
        public double Total { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace coderush.Models
{
    public class StockBilOfMaterial
    {
        public int StockBilOfMaterialId { get; set; }
        [Required]
        public int StockId { get; set; }
        public int Child_StockId { get; set; }
        public int QTY { get; set; }
    }
}

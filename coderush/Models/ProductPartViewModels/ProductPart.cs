using System.ComponentModel.DataAnnotations;

namespace coderush.Models
{
    public class ProductPart
    {
        public int ProductPartId { get; set; } = 0;

        public int ProductId { get; set; } = 0;

        public int PartId { get; set; } = 0;

        public int QTY { get; set; } = 0;

        [MaxLength(100)]
        public string Description { get; set; } = "";
    }
}

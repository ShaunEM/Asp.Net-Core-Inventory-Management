using System.ComponentModel.DataAnnotations;

namespace coderush.Models
{
    public class Stock
    {
        public int StockId { get; set; }

        [Display(Name = "Stock Type")]
        public int StockTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string StockName { get; set; }

        [Display(Name = "Description")]
        [MaxLength(100)]
        public string Description { get; set; } = "";

        [Display(Name = "Internal Part Number")]
        [MaxLength(100)]
        public string InternalPartNumber { get; set; } = "";



        [Display(Name = "Unit Of Measure")]
        public int UnitOfMeasureId { get; set; }

        [MaxLength(100)]
        public string Footprint { get; set; } = "";

        [MaxLength(100)]
        public string Note { get; set; } = "";
       
    }
}

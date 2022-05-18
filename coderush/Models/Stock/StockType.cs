using System.ComponentModel.DataAnnotations;

namespace coderush.Models
{
    public class StockType
    {
        public int StockTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
    }
}

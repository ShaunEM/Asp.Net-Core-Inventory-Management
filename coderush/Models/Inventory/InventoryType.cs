using System.ComponentModel.DataAnnotations;

namespace coderush.Models
{
    public class InventoryType
    {
        public int InventoryTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string InventoryTypeName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace coderush.Models
{
    public class SupplierType
    {
        public int SupplierTypeId { get; set; }
        [Required]
        [MaxLength(50)]
        public string SupplierTypeName { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }
}

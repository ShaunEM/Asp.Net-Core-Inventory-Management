using System.ComponentModel.DataAnnotations;

namespace coderush.Models
{
    public class SalesType
    {
        public int SalesTypeId { get; set; }
        [Required]
        [MaxLength(50)]
        public string SalesTypeName { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace coderush.Models
{
    public class PartType
    {
        public int PartTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string PartTypeName { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }
}

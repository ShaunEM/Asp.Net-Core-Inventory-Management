using System.ComponentModel.DataAnnotations;

namespace coderush.Models
{
    public class UnitOfMeasure
    {
        [Key]
        public int UnitOfMeasureId { get; set; }

        [Required]
        [MaxLength(6)]
        public string DisplayName { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }
}

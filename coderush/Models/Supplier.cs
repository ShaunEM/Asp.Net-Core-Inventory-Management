using System.ComponentModel.DataAnnotations;

namespace coderush.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        
        [Required]
        [DataType("NVARCHAR"), MaxLength(50)]
        public string SupplierName { get; set; }

        [Display(Name = "Supplier Type")]
        public int SupplierTypeId { get; set; }
        
        [Display(Name = "Street Address")]
        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(100)]
        public string State { get; set; }
        
        [Display(Name = "Website")]
        [MaxLength(100)]
        public string Website { get; set; }

        [MaxLength(100)]
        public string Phone { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [Display(Name = "Contact Person")]
        [MaxLength(100)]
        public string ContactPerson { get; set; }
    }
}

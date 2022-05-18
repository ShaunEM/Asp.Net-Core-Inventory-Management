using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coderush.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string Description { get; set; }

        [Display(Name = "Internal Part Number")]
        [MaxLength(100)]
        public string InternalPartNumber { get; set; }
        public string ProductImageUrl { get; set; }
        
        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }
    }
}

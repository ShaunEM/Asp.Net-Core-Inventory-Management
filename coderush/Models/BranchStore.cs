using System.ComponentModel.DataAnnotations;

namespace coderush.Models
{
    public class BranchStore
    {
        public int BranchStoreId { get; set; }
        [Required]
        public string BranchStoreName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace coderush.Models
{
    public class Part
    {
        /*
            Storage Location
            Minimum Stock
            Initial Stock Level
            Price
            Distributors
            Manufactures
            Part Parameters
            Attachments 
        */
        public int PartId { get; set; }

        [Required]
        [MaxLength(50)]
        public string PartName { get; set; }

        [Display(Name = "Part Type")]
        public int PartTypeId { get; set; }

        [Display(Name = "Unit Of Measure")]
        public int UnitOfMeasureId { get; set; }

        [Display(Name = "Description")]
        [MaxLength(100)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Footprint { get; set; }

        [MaxLength(100)]
        public string Comment { get; set; }
        
        [Display(Name = "Production Remarks")]
        [MaxLength(100)]
        public string ProductionRemarks { get; set; }

        [Display(Name = "Internal Part Number")]
        [MaxLength(100)]
        public string InternalPartNumber { get; set; }
    }
}

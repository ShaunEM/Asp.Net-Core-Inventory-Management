using System;
using System.ComponentModel.DataAnnotations;

namespace coderush.Models
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        [Display(Name = "Shipment Number")]
        public string ShipmentName { get; set; }

        public DateTimeOffset ShipmentDate { get; set; }
        
        [Display(Name = "Shipment Type")]
        public int ShipmentTypeId { get; set; }
        
        [Display(Name = "Sales order")]
        public int SalesOrderId { get; set; }


        [Display(Name = "From Store")]
        public int BranchStoreId { get; set; }
    }
}

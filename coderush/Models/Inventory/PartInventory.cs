using System;
using System.ComponentModel.DataAnnotations;

namespace coderush.Models
{
    public class PartInventory
    {
        public int PartInventoryId { get; set; }
        public int BranchAreaId { get; set; }
        public int PartId { get; set; }
        public int QTY { get; set; }
        public int InventoryTypeId { get; set; }
        public int TableId { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }
}

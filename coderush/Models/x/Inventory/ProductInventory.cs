using System;

namespace coderush.Models
{
    public class ProductInventory
    {
        public int ProductInventoryId { get; set; }
        public int BranchAreaId { get; set; }
        public int ProductId { get; set; }
        public int QTY { get; set; }
        public int InventoryTypeId { get; set; }
        public int TableId { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }
}

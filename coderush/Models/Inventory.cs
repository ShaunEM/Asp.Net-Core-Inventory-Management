using System;
using System.ComponentModel.DataAnnotations;

namespace coderush.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public int BranchStoreId { get; set; }
        public int StockId { get; set; }
        public DateTimeOffset DateTime { get; set; }
        //public int InventoryTypeId { get; set; }
        public int QTYChange { get; set; }
        public int QTY { get; set; }
        //public int TableId { get; set; }
    }
}

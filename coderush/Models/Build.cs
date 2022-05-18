using System;
namespace coderush.Models
{
    public class Build
    {
        public int BuildId { get; set; }
        public int BranchStoreId { get; set; }
        public int StockId { get; set; }
        public int QTY { get; set; }
        public DateTime BuildDateTime { get; set; }
        public string Reference { get; set; }
    }
}

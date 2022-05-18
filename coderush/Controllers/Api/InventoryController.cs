using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using coderush.Data;
using coderush.Models;
using Microsoft.AspNetCore.Authorization;

namespace coderush.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Inventory")]
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoryController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetInventoryAsync()
        {
            _ = int.TryParse(Request.Headers["BranchId"], out int branchId);
            _ = int.TryParse(Request.Headers["BranchStoreId"], out int branchStoreId);
            return await GetInventoryAsync(branchId, branchStoreId);
        }

        [NonAction]
        private async Task<IActionResult> GetInventoryAsync(int branchId, int branchStoreId)
        {
            int[] storeIds = branchStoreId > 0 ? new int[] { branchStoreId } :
                await _context.BranchStore
                .Where(x => x.BranchId == branchId)
                .Select(x => x.BranchStoreId)
                .ToArrayAsync();

            var Items = _context.Inventory
                .Where(x => storeIds.Contains(x.BranchStoreId))
                .Join(_context.Stock, o => o.StockId, i => i.StockId, (o, i) => new
                {
                    o.StockId,
                    o.BranchStoreId,
                    o.InventoryId,
                    i.StockName,
                    i.InternalPartNumber,
                    o.QTY
                })
                .ToList()
                .GroupBy(p => new { p.StockId, p.BranchStoreId })
                .Select(g => g.OrderByDescending(x => x.InventoryId))
                .Select(x => x.FirstOrDefault())
                .GroupBy(p => new { p.StockId, p.StockName, p.InternalPartNumber })
                .Select(grp => new
                {
                    grp.Key.StockId,
                    grp.Key.StockName,
                    grp.Key.InternalPartNumber,
                    Total = grp.Sum(x => x.QTY)
                })
                .ToList();

            return Ok(new
            {
                Items,
                Items.Count
            });
        }



        [HttpPost("[action]")]
        public IActionResult TransferStock(int fromBranchStoreId, int toBranchStoreId, int stockId, int qty, string reference)
        {
            Inventory lastFromInventory = _context.Inventory.Where(x => x.BranchStoreId == fromBranchStoreId && x.StockId == stockId)?.OrderByDescending(x => x.InventoryId)?.FirstOrDefault();
            Inventory lastToInventory = _context.Inventory.Where(x => x.BranchStoreId == toBranchStoreId && x.StockId == stockId)?.OrderByDescending(x => x.InventoryId)?.FirstOrDefault();
            _context.Inventory.Add(new Inventory()
            {
                BranchStoreId = fromBranchStoreId,
                StockId = stockId,
                DateTime = DateTime.Now,
                QTYChange = qty * -1,
                QTY = (lastFromInventory?.QTY ?? 0) - qty
            });
            _context.Inventory.Add(new Inventory()
            {
                BranchStoreId = toBranchStoreId,
                StockId = stockId,
                DateTime = DateTime.Now,
                QTYChange = qty,
                QTY = (lastToInventory?.QTY ?? 0) + qty
            });
            _context.SaveChanges();
            return Ok();
        }






        //[HttpGet("[action]/{id}")]
        //public IActionResult GetInventoryByBranchStoreId(int id)
        //{
        //    var Items = _context.Inventory
        //        .Where(x => id > 0 ? x.BranchStoreId == id : x.BranchStoreId > 0)
        //        .Join(_context.Stock, o => o.StockId, i => i.StockId, (o, i) => new
        //        {
        //            o.StockId,
        //            o.InventoryId,
        //            i.StockName,
        //            o.QTY
        //        })
        //        .ToList()
        //        .GroupBy(p => p.StockId)
        //        .Select(g => g.OrderByDescending(x => x.InventoryId))
        //        .Select(x => x.FirstOrDefault())
        //        .ToList();
        //    int Count = Items.Count();
        //    return Ok(new { Items, Count });
        //}





        //[HttpGet("[action]")]
        //public IActionResult GetPartsByBranchAreaId()
        //{
        //    throw new NotImplementedException();
        //    //var headerBranchAreaId = Request.Headers["BranchAreaId"];
        //    //int branchAreaId = Convert.ToInt32(headerBranchAreaId);
        //    //// Join not required at this stage
        //    //var Items = (
        //    //                from pi in _context.PartInventory
        //    //                join p in _context.Part on pi.PartId equals p.PartId
        //    //                where pi.PartId == p.PartId && pi.BranchAreaId == branchAreaId
        //    //                group pi by new { p.PartName, p.InternalPartNumber, p.PartId } into g
        //    //                select new
        //    //                {
        //    //                    g.Key.PartName,
        //    //                    g.Key.InternalPartNumber,
        //    //                    QTY = g.Sum(x => x.QTY)
        //    //                }
        //    //            );
        //    //int Count = Items.Count();
        //    //return Ok(new { Items, Count });
        //}


        //[HttpGet("[action]")]
        //public IActionResult GetProductsByBranchAreaId()
        //{
        //    throw new NotImplementedException();
        //    // working ver
        //    //var headerBranchAreaId = Request.Headers["BranchAreaId"];
        //    //int branchAreaId = Convert.ToInt32(headerBranchAreaId);
        //    //var Items = (
        //    //                from pi in _context.PartInventory
        //    //                join p in _context.Part on pi.PartId equals p.PartId
        //    //                where pi.PartId == p.PartId && pi.BranchAreaId == branchAreaId
        //    //                group pi by new { p.PartName, p.InternalPartNumber, p.PartId } into g
        //    //                select new
        //    //                {
        //    //                    g.Key.PartName,
        //    //                    g.Key.InternalPartNumber,
        //    //                    QTY = g.Sum(x => x.QTY)
        //    //                }
        //    //            );



        //    ////// Join not required at this stage
        //    ////var Items = (
        //    ////                from pi in _context.ProductInventory
        //    ////                join p in _context.Product on pi.ProductId equals p.ProductId
        //    ////                where pi.PartId == p.PartId && pi.BranchAreaId == branchAreaId
        //    ////                group pi by new { p.ProductName, p.InternalPartNumber, p.ProductId } into g
        //    ////                select new
        //    ////                {
        //    ////                    g.Key.ProductName,
        //    ////                    g.Key.InternalPartNumber,
        //    ////                    QTY = g.Sum(x => x.QTY)
        //    ////                }
        //    ////            );
        //    //int Count = Items.Count();
        //    //return Ok(new { Items, Count });
        //}

    }
}
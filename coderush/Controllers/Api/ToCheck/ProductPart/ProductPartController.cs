using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using coderush.Data;
using coderush.Models;
using coderush.Models.SyncfusionViewModels;
using Microsoft.AspNetCore.Authorization;

namespace coderush.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/ProductPart")]
    public class ProductPartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductPartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductPartLine
        [HttpGet]
        public async Task<IActionResult> GetProductPart()
        {
            throw new NotImplementedException();
            //var headers = Request.Headers["ProductId"];
            //int productId = Convert.ToInt32(headers);

            //// Join not required at this stage
            //var Items = (from pp in _context.ProductPart
            //             join p in _context.Part on pp.PartId equals p.PartId
            //             join pt in _context.PartType on p.PartTypeId equals pt.PartTypeId
            //             select new
            //             {
            //                 pp.ProductPartId,
            //                 pp.ProductId,
            //                 pp.QTY,
            //                 pt.PartTypeId,
            //                 pp.Description,
            //                 // pt.PartTypeName,
            //                 p.PartId,
            //                 // p.PartName,
            //                 p.InternalPartNumber,

            //             }).Where(pp => pp.ProductId == productId);


            //int Count = Items.Count();
            //return Ok(new { Items, Count });
        }

        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetSalesOrderLineByShipmentId()
        //{
        //    var headers = Request.Headers["ShipmentId"];
        //    int shipmentId = Convert.ToInt32(headers);
        //    Shipment shipment = await _context.Shipment.SingleOrDefaultAsync(x => x.ShipmentId.Equals(shipmentId));
        //    List<SalesOrderLine> Items = new List<SalesOrderLine>();
        //    if (shipment != null)
        //    {
        //        int salesOrderId = shipment.SalesOrderId;
        //        Items = await _context.SalesOrderLine
        //            .Where(x => x.SalesOrderId.Equals(salesOrderId))
        //            .ToListAsync();
        //    }
        //    int Count = Items.Count();
        //    return Ok(new { Items, Count });
        //}

        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetSalesOrderLineByInvoiceId()
        //{
        //    var headers = Request.Headers["InvoiceId"];
        //    int invoiceId = Convert.ToInt32(headers);
        //    Invoice invoice = await _context.Invoice.SingleOrDefaultAsync(x => x.InvoiceId.Equals(invoiceId));
        //    List<SalesOrderLine> Items = new List<SalesOrderLine>();
        //    if (invoice != null)
        //    {
        //        int shipmentId = invoice.ShipmentId;
        //        Shipment shipment = await _context.Shipment.SingleOrDefaultAsync(x => x.ShipmentId.Equals(shipmentId));
        //        if (shipment != null)
        //        {
        //            int salesOrderId = shipment.SalesOrderId;
        //            Items = await _context.SalesOrderLine
        //                .Where(x => x.SalesOrderId.Equals(salesOrderId))
        //                .ToListAsync();
        //        }
        //    }
        //    int Count = Items.Count();
        //    return Ok(new { Items, Count });
        //}

        //private SalesOrderLine Recalculate(SalesOrderLine salesOrderLine)
        //{
        //    try
        //    {
        //        salesOrderLine.Amount = salesOrderLine.Quantity * salesOrderLine.Price;
        //        salesOrderLine.DiscountAmount = (salesOrderLine.DiscountPercentage * salesOrderLine.Amount) / 100.0;
        //        salesOrderLine.SubTotal = salesOrderLine.Amount - salesOrderLine.DiscountAmount;
        //        salesOrderLine.TaxAmount = (salesOrderLine.TaxPercentage * salesOrderLine.SubTotal) / 100.0;
        //        salesOrderLine.Total = salesOrderLine.SubTotal + salesOrderLine.TaxAmount;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    return salesOrderLine;
        //}

        //private void UpdateProductPart(int productPartId)
        //{
        //    try
        //    {
        //        Part salesOrder = new Part();
        //        salesOrder = _context.SalesOrder
        //            .Where(x => x.SalesOrderId.Equals(salesOrderId))
        //            .FirstOrDefault();

        //        if (salesOrder != null)
        //        {
        //            List<SalesOrderLine> lines = new List<SalesOrderLine>();
        //            lines = _context.SalesOrderLine.Where(x => x.SalesOrderId.Equals(salesOrderId)).ToList();

        //            //update master data by its lines
        //            salesOrder.Amount = lines.Sum(x => x.Amount);
        //            salesOrder.SubTotal = lines.Sum(x => x.SubTotal);

        //            salesOrder.Discount = lines.Sum(x => x.DiscountAmount);
        //            salesOrder.Tax = lines.Sum(x => x.TaxAmount);

        //            salesOrder.Total = salesOrder.Freight + lines.Sum(x => x.Total);

        //            _context.Update(salesOrder);

        //            _context.SaveChanges();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<ProductPart> payload)
        {
            ProductPart item = payload.value;
            _context.ProductPart.Add(item);
            _context.SaveChanges();
            return Ok(item);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<ProductPart> payload)
        {
            ProductPart item = payload.value;
            //item = this.Recalculate(item);
            _context.ProductPart.Update(item);
            _context.SaveChanges();

            //this.UpdateProductPart(item.ProductPartId);
            return Ok(item);


        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<ProductPart> payload)
        {
            ProductPart item = _context.ProductPart
                .Where(x => x.ProductPartId == Convert.ToInt32(payload.key))
                .FirstOrDefault();

            _context.ProductPart.Remove(item);
            _context.SaveChanges();
            //this.UpdateSalesOrder(salesOrderLine.SalesOrderId);
            return Ok(item);

        }
    }
}
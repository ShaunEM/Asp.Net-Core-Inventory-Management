﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using coderush.Data;
using coderush.Models;
using coderush.Models.SyncfusionViewModels;
using Microsoft.AspNetCore.Authorization;

namespace coderush.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/SalesOrderDetail")]
    public class SalesOrderDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesOrderDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SalesOrderLine
        [HttpGet]
        public async Task<IActionResult> GetSalesOrderLine()
        {
            var headers = Request.Headers["SalesOrderId"];
            int salesOrderId = Convert.ToInt32(headers);
            List<SalesOrderDetail> Items = await _context.SalesOrderDetail
                .Where(x => x.SalesOrderId.Equals(salesOrderId))
                .ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
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

        private SalesOrderDetail Recalculate(SalesOrderDetail salesOrderLine)
        {
            try
            {
                salesOrderLine.Amount = salesOrderLine.Quantity * salesOrderLine.Price;
                salesOrderLine.DiscountAmount = (salesOrderLine.DiscountPercentage * salesOrderLine.Amount) / 100.0;
                salesOrderLine.SubTotal = salesOrderLine.Amount - salesOrderLine.DiscountAmount;
                salesOrderLine.TaxAmount = (salesOrderLine.TaxPercentage * salesOrderLine.SubTotal) / 100.0;
                salesOrderLine.Total = salesOrderLine.SubTotal + salesOrderLine.TaxAmount;

            }
            catch (Exception)
            {

                throw;
            }

            return salesOrderLine;
        }

        private void UpdateSalesOrder(int salesOrderId)
        {
            try
            {
                SalesOrder salesOrder = new SalesOrder();
                salesOrder = _context.SalesOrder
                    .Where(x => x.SalesOrderId.Equals(salesOrderId))
                    .FirstOrDefault();

                if (salesOrder != null)
                {
                    List<SalesOrderDetail> lines = new List<SalesOrderDetail>();
                    lines = _context.SalesOrderDetail.Where(x => x.SalesOrderId.Equals(salesOrderId)).ToList();

                    //update master data by its lines
                    salesOrder.Amount = lines.Sum(x => x.Amount);
                    salesOrder.SubTotal = lines.Sum(x => x.SubTotal);

                    salesOrder.Discount = lines.Sum(x => x.DiscountAmount);
                    salesOrder.Tax = lines.Sum(x => x.TaxAmount);

                    salesOrder.Total = salesOrder.Freight + lines.Sum(x => x.Total);

                    _context.Update(salesOrder);

                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<SalesOrderDetail> payload)
        {
            SalesOrderDetail salesOrderLine = payload.value;
            salesOrderLine = this.Recalculate(salesOrderLine);
            _context.SalesOrderDetail.Add(salesOrderLine);
            _context.SaveChanges();

            this.UpdateSalesOrder(salesOrderLine.SalesOrderId);
            return Ok(salesOrderLine);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<SalesOrderDetail> payload)
        {
            SalesOrderDetail salesOrderLine = payload.value;
            salesOrderLine = this.Recalculate(salesOrderLine);
            _context.SalesOrderDetail.Update(salesOrderLine);
            _context.SaveChanges();

            this.UpdateSalesOrder(salesOrderLine.SalesOrderId);
            return Ok(salesOrderLine);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<SalesOrderDetail> payload)
        {
            SalesOrderDetail salesOrderLine = _context.SalesOrderDetail
                .Where(x => x.SalesOrderDetailId == Convert.ToInt32(payload.key))
                .FirstOrDefault();
            _context.SalesOrderDetail.Remove(salesOrderLine);
            _context.SaveChanges();

            this.UpdateSalesOrder(salesOrderLine.SalesOrderId);
            return Ok(salesOrderLine);

        }
    }
}
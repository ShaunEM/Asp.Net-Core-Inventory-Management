using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    [Route("api/PurchaseOrderLine")]
    public class PurchaseOrderLineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseOrderLineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseOrderLine
        [HttpGet]
        public async Task<IActionResult> GetPurchaseOrderLine()
        {
            var headers = Request.Headers["PurchaseOrderId"];
            int purchaseOrderId = Convert.ToInt32(headers);
            List<PurchaseOrderLine> Items = await _context.PurchaseOrderLine
                .Where(x => x.PurchaseOrderId.Equals(purchaseOrderId))
                .ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        private PurchaseOrderLine Recalculate(PurchaseOrderLine purchaseOrderLine)
        {
            try
            {
                purchaseOrderLine.Total = purchaseOrderLine.QTY * purchaseOrderLine.UnitPrice;

            }
            catch (Exception)
            {

                throw;
            }

            return purchaseOrderLine;
        }

        private void UpdatePurchaseOrder(int purchaseOrderId)
        {
            try
            {
                PurchaseOrder purchaseOrder = new PurchaseOrder();
                purchaseOrder = _context.PurchaseOrder
                    .Where(x => x.PurchaseOrderId.Equals(purchaseOrderId))
                    .FirstOrDefault();

                if (purchaseOrder != null)
                {
                    List<PurchaseOrderLine> lines = new List<PurchaseOrderLine>();
                    lines = _context.PurchaseOrderLine.Where(x => x.PurchaseOrderId.Equals(purchaseOrderId)).ToList();


                    purchaseOrder.Total = lines.Sum(x => x.Total);

                    _context.Update(purchaseOrder);

                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<PurchaseOrderLine> payload)
        {
            PurchaseOrderLine purchaseOrderLine = payload.value;
            purchaseOrderLine = this.Recalculate(purchaseOrderLine);
            _context.PurchaseOrderLine.Add(purchaseOrderLine);
            _context.SaveChanges();
            this.UpdatePurchaseOrder(purchaseOrderLine.PurchaseOrderId);
            return Ok(purchaseOrderLine);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<PurchaseOrderLine> payload)
        {
            PurchaseOrderLine purchaseOrderLine = payload.value;
            purchaseOrderLine = this.Recalculate(purchaseOrderLine);
            _context.PurchaseOrderLine.Update(purchaseOrderLine);
            _context.SaveChanges();
            this.UpdatePurchaseOrder(purchaseOrderLine.PurchaseOrderId);
            return Ok(purchaseOrderLine);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<PurchaseOrderLine> payload)
        {
            int purchaseOrderId = Convert.ToInt32(payload.key);

            PurchaseOrderLine purchaseOrderLine = _context.PurchaseOrderLine
                .Where(x => x.PurchaseOrderLineId == purchaseOrderId)
                .FirstOrDefault();
            _context.PurchaseOrderLine.Remove(purchaseOrderLine);
            _context.SaveChanges();
            this.UpdatePurchaseOrder(purchaseOrderLine.PurchaseOrderId);
            return Ok(purchaseOrderLine);

        }
    }
}
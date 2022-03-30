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
    [Route("api/Inventory")]
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoryController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetByBranchAreaId()
        {
            var headerBranchAreaId = Request.Headers["BranchAreaId"];
            int branchAreaId = Convert.ToInt32(headerBranchAreaId);

            var Items = new []
            {
                new {
                    Name = "Bobx",
                    InternalPartNumber = "Marleyx",
                    QTY = 0
                },
                new {
                    Name = "Bobx",
                    InternalPartNumber = "Marleyx",
                    QTY = 0
                }
            };

            // TODO
            // create a view (include PART, and PRODUCT)
            // Create PART VIEW model (Name, internal part number, QTY.. value?)
            // Create PRODUCT VIEW model (Name, internal part number, QTY.. value?)
            // create the view, display parts and products in separate tables.


            //  List<Part> Items = await _context.Part.Where(x => x.PartTypeId.Equals(id)).ToListAsync();
            //return Ok(new { Items, Items.Count });



            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


    }
}
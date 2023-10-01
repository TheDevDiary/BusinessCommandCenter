using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/vendors")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/vendors
        [HttpGet]
        public ActionResult<IEnumerable<Vendor>> GetVendors()
        {
            return _context.Vendors.ToList();
        }

        // GET: api/vendors/{id}
        [HttpGet("{id}")]
        public ActionResult<Vendor> GetVendorById(int id)
        {
            var vendor = _context.Vendors.FirstOrDefault(v => v.Id == id);

            if (vendor == null)
            {
                return NotFound();
            }

            return vendor;
        }

        // POST: api/vendors
        [HttpPost]
        public ActionResult<Vendor> CreateVendor(Vendor vendor)
        {
            _context.Vendors.Add(vendor);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetVendorById), new { id = vendor.Id }, vendor);
        }
    }
}

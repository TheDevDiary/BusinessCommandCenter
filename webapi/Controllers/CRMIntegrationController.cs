using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/crmintegrations")]
    [ApiController]
    public class CRMIntegrationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CRMIntegrationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/crmintegrations
        [HttpGet]
        public ActionResult<IEnumerable<CRMIntegration>> GetCRMIntegrations()
        {
            return _context.CRMIntegrations.ToList();
        }

        // GET: api/crmintegrations/{id}
        [HttpGet("{id}")]
        public ActionResult<CRMIntegration> GetCRMIntegrationById(int id)
        {
            var crmIntegration = _context.CRMIntegrations.FirstOrDefault(ci => ci.Id == id);

            if (crmIntegration == null)
            {
                return NotFound();
            }

            return crmIntegration;
        }

        // POST: api/crmintegrations
        [HttpPost]
        public ActionResult<CRMIntegration> CreateCRMIntegration(CRMIntegration crmIntegration)
        {
            _context.CRMIntegrations.Add(crmIntegration);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCRMIntegrationById), new { id = crmIntegration.Id }, crmIntegration);
        }
    }
}

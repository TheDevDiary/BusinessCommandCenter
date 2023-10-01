using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/hrdocuments")]
    [ApiController]
    public class HRDocumentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HRDocumentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/hrdocuments
        [HttpGet]
        public ActionResult<IEnumerable<HRDocument>> GetHRDocuments()
        {
            return _context.HRDocuments.ToList();
        }

        // GET: api/hrdocuments/{id}
        [HttpGet("{id}")]
        public ActionResult<HRDocument> GetHRDocumentById(int id)
        {
            var document = _context.HRDocuments.Find(id);

            if (document == null)
            {
                return NotFound();
            }

            return document;
        }

        // POST: api/hrdocuments
        [HttpPost]
        public ActionResult<HRDocument> CreateHRDocument(HRDocument document)
        {
            _context.HRDocuments.Add(document);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetHRDocumentById), new { id = document.Id }, document);
        }
    }
}

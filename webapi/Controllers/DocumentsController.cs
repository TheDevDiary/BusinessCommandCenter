using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/documents")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DocumentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/documents
        [HttpGet]
        public ActionResult<IEnumerable<Document>> GetDocuments()
        {
            return _context.Documents.ToList();
        }

        // GET: api/documents/{id}
        [HttpGet("{id}")]
        public ActionResult<Document> GetDocumentById(int id)
        {
            var document = _context.Documents.Find(id);

            if (document == null)
            {
                return NotFound();
            }

            return document;
        }

        // POST: api/documents
        [HttpPost]
        public ActionResult<Document> CreateDocument(Document document)
        {
            // Set upload date to current date
            document.UploadDate = DateTime.UtcNow;

            _context.Documents.Add(document);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetDocumentById), new { id = document.Id }, document);
        }
    }
}

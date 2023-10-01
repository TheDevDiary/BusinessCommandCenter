using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/performancereviews")]
    [ApiController]
    public class PerformanceReviewsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PerformanceReviewsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/performancereviews
        [HttpGet]
        public ActionResult<IEnumerable<PerformanceReview>> GetPerformanceReviews()
        {
            return _context.PerformanceReviews.Include(pr => pr.Employee).ToList();
        }

        // GET: api/performancereviews/{id}
        [HttpGet("{id}")]
        public ActionResult<PerformanceReview> GetPerformanceReviewById(int id)
        {
            var review = _context.PerformanceReviews.Include(pr => pr.Employee).FirstOrDefault(pr => pr.Id == id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        // POST: api/performancereviews
        [HttpPost]
        public ActionResult<PerformanceReview> CreatePerformanceReview(PerformanceReview review)
        {
            _context.PerformanceReviews.Add(review);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPerformanceReviewById), new { id = review.Id }, review);
        }
    }
}

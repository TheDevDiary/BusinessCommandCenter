using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerSupportTicketsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomerSupportTicketsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerSupportTickets
        [HttpGet]
        public ActionResult<IEnumerable<CustomerSupportTicket>> GetCustomerSupportTickets()
        {
            return _context.CustomerSupportTickets.ToList();
        }

        // GET: api/CustomerSupportTickets/{id}
        [HttpGet("{id}")]
        public ActionResult<CustomerSupportTicket> GetCustomerSupportTicket(int id)
        {
            var ticket = _context.CustomerSupportTickets.Find(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        // POST: api/CustomerSupportTickets
        [HttpPost]
        public ActionResult<CustomerSupportTicket> CreateCustomerSupportTicket(CustomerSupportTicket ticket)
        {
            ticket.CreatedDate = DateTime.UtcNow;
            ticket.IsResolved = false;

            _context.CustomerSupportTickets.Add(ticket);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCustomerSupportTicket), new { id = ticket.Id }, ticket);
        }

        // PUT: api/CustomerSupportTickets/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCustomerSupportTicket(int id, CustomerSupportTicket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticket).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/CustomerSupportTickets/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomerSupportTicket(int id)
        {
            var ticket = _context.CustomerSupportTickets.Find(id);

            if (ticket == null)
            {
                return NotFound();
            }

            _context.CustomerSupportTickets.Remove(ticket);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

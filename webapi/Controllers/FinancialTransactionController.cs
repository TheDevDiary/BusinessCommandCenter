using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/financialtransactions")]
    [ApiController]
    public class FinancialTransactionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FinancialTransactionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/financialtransactions
        [HttpGet]
        public ActionResult<IEnumerable<FinancialTransaction>> GetFinancialTransactions()
        {
            return _context.FinancialTransactions.ToList();
        }

        // GET: api/financialtransactions/{id}
        [HttpGet("{id}")]
        public ActionResult<FinancialTransaction> GetFinancialTransactionById(int id)
        {
            var transaction = _context.FinancialTransactions.Find(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        // POST: api/financialtransactions
        [HttpPost]
        public ActionResult<FinancialTransaction> CreateFinancialTransaction(FinancialTransaction transaction)
        {
            _context.FinancialTransactions.Add(transaction);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetFinancialTransactionById), new { id = transaction.Id }, transaction);
        }
    }
}

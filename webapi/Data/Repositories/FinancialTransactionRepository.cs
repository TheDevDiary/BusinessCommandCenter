using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data.Repositories
{
    public class FinancialTransactionRepository : IFinancialTransactionRepository
    {
        private readonly AppDbContext _dbContext;

        public FinancialTransactionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public FinancialTransaction GetFinancialTransactionById(int transactionId)
        {
            return _dbContext.FinancialTransactions
                .FirstOrDefault(ft => ft.Id == transactionId);
        }

        public List<FinancialTransaction> GetFinancialTransactionsByUserId(int userId)
        {
            return _dbContext.FinancialTransactions
                .Where(ft => ft.UserId == userId)
                .ToList();
        }

        public void AddFinancialTransaction(FinancialTransaction transaction)
        {
            _dbContext.FinancialTransactions.Add(transaction);
            _dbContext.SaveChanges();
        }

        public void UpdateFinancialTransaction(FinancialTransaction transaction)
        {
            _dbContext.FinancialTransactions.Update(transaction);
            _dbContext.SaveChanges();
        }

        public void DeleteFinancialTransaction(int transactionId)
        {
            var transaction = _dbContext.FinancialTransactions.Find(transactionId);
            if (transaction != null)
            {
                _dbContext.FinancialTransactions.Remove(transaction);
                _dbContext.SaveChanges();
            }
        }
    }
}

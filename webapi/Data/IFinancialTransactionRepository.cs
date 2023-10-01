using System;
using System.Collections.Generic;
using webapi.Models;

namespace webapi.Data.Repositories
{
    public interface IFinancialTransactionRepository
    {
        FinancialTransaction GetFinancialTransactionById(int transactionId);
        List<FinancialTransaction> GetFinancialTransactionsByUserId(int userId);
        void AddFinancialTransaction(FinancialTransaction transaction);
        void UpdateFinancialTransaction(FinancialTransaction transaction);
        void DeleteFinancialTransaction(int transactionId);
    }
}

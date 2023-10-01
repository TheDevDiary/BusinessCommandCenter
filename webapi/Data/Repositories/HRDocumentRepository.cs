using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data.Repositories
{
    public class HRDocumentRepository
    {
        private readonly AppDbContext _dbContext;
        public HRDocumentRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public HRDocument GetHRDocumentById(int documentId)
        {
            return _dbContext.HRDocuments
                .FirstOrDefault(doc => doc.Id == documentId);
        }
        List<HRDocument> GetHRDocumentsByEmployee(int employeeId)
        {
            return _dbContext.HRDocuments
                .Where(doc => doc.EmployeeId == employeeId).ToList();
        }
        void AddHRDocument(HRDocument document)
        {
            _dbContext.HRDocuments.Add(document);
            _dbContext.SaveChanges();
        }
        void UpdateHRDocument(HRDocument document)
        {
            _dbContext.HRDocuments.Update(document);
            _dbContext.SaveChanges();

        }
        void DeleteHRDocument(int documentId)
        {
            var document = _dbContext.HRDocuments.Find(documentId);
            if (document != null)
            {
                _dbContext.HRDocuments.Remove(document);
                _dbContext.SaveChanges();
            }
        }
    }
}

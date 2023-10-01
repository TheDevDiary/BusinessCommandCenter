using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data.Repositories
{
    public class DocumentRepository 
    {
        private readonly AppDbContext _dbContext;

        public DocumentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Document? GetDocumentById(int documentId)
        {
            return _dbContext.Documents
                .Include(d => d.User)
                .FirstOrDefault(d => d.Id == documentId);
        }

        public List<Document> GetDocumentsByUserId(int userId)
        {
            return _dbContext.Documents
                .Where(d => d.UserId == userId)
                .ToList();
        }

        public void AddDocument(Document document)
        {
            _dbContext.Documents.Add(document);
            _dbContext.SaveChanges();
        }

        public void UpdateDocument(Document document)
        {
            _dbContext.Documents.Update(document);
            _dbContext.SaveChanges();
        }

        public void DeleteDocument(int documentId)
        {
            var document = _dbContext.Documents.Find(documentId);
            if (document != null)
            {
                _dbContext.Documents.Remove(document);
                _dbContext.SaveChanges();
            }
        }
    }
}

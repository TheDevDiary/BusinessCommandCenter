using System;
using System.Collections.Generic;
using webapi.Models;

namespace webapi.Data
{
    public interface IDocumentRepository
    {
        Document GetDocumentById(int documentId);
        List<Document> GetDocumentsByUserId(int userId);
        void AddDocument(Document document);
        void UodateDocument(Document document);
        void DeleteDocument(int documentId);
    }
}

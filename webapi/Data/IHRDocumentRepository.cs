using System;
using System.Collections.Generic;
using webapi.Models;

namespace webapi.Data
{
    public interface IHRDocumentRepository
    {
        HRDocument GetHRDocumentById(int documentId);
        List<HRDocument> GetHRDocumentsByEmployee(int  employeeId);
        void AddHRDocument(HRDocument document);
        void UpdateHRDocument(HRDocument document);
        void DeleteHRDocument(int documentId);
    }
}

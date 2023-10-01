using System;
using System.Collections.Generic;
using webapi.Models;

namespace webapi.Data
{
    public interface IPerformanceReviewRepository
    {
        PerformanceReview GetPerformanceReviewById(int reviewId);
        List<PerformanceReview> GetPerformanceReviewsByEmployee(int employee);
        void AddPerformanceReview(PerformanceReview review);
        void UpdatePerformanceReview(PerformanceReview review);
        void DeletePerformanceReview(int reviewId);
    }
}

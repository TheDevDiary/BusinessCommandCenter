using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data.Repositories 
{
    public class PerformanceReviewRepository : IPerformanceReviewRepository
    {
        private readonly AppDbContext _dbContext;
        public PerformanceReviewRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public PerformanceReview GetPerformanceReviewById(int reviewId)
        {
            return _dbContext.PerformanceReviews
                .Include(pr => pr.Employee)
                .Include(pr => pr.Reviewer)
                .FirstOrDefault(pr => pr.Id == reviewId);
        }
        public List<PerformanceReview> GetPerformanceReviewsByEmployee(int employeeId) 
        {
            return _dbContext.PerformanceReviews
                .Where(pr => pr.EmployeeId == employeeId).ToList();
        }

        // Add 
        public void AddPerformanceReview(PerformanceReview review)
        {
            _dbContext.PerformanceReviews .Add(review);
            _dbContext.SaveChanges();
        }
        // Update
        public void UpdatePerformanceReview(PerformanceReview review)
        {
            _dbContext.PerformanceReviews.Update(review);
            _dbContext.SaveChanges();
        }
        // Delete
        public void DeletePerformanceReview(int reviewId)
        {
            var review = _dbContext.PerformanceReviews.Find(reviewId);
            if (review != null)
            {
                _dbContext.PerformanceReviews.Remove(review);
                _dbContext.SaveChanges();
            }
        }
    }
}

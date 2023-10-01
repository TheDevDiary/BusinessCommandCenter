using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data.Repositories
{
    public class TimeAttendanceRepository : ITimeAttendanceRepository
    {
        private readonly AppDbContext _dbContext;
        public TimeAttendanceRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public TimeAttendance GetTimeAttendanceById(int attendaceId)
        {
            return _dbContext.TimeAttendances
                .FirstOrDefault(ta => ta.Id == attendaceId);
        }
        public List<TimeAttendance> GetTimeAttendanceByUserId(int userId)
        {
            return _dbContext.TimeAttendances
                .Where(ta => ta.UserId == userId)
                .ToList();
        }
        public void AddTimeAttendance(TimeAttendance attendance)
        {
            _dbContext.TimeAttendances.Add(attendance);
            _dbContext.SaveChanges();
        }
        public void UpdateTimeAttendance(TimeAttendance attendance)
        {
            _dbContext.TimeAttendances.Update(attendance);
            _dbContext.SaveChanges();
        }
        public void DeleteTimeAttendance(int attendancesId)
        {
            var attendance = _dbContext.TimeAttendances.Find(attendancesId);
            if (attendance != null)
            {
                _dbContext.TimeAttendances.Remove(attendance);
                _dbContext.SaveChanges();
            }
        }
    }
}

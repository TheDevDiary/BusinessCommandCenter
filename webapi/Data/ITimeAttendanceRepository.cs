using webapi.Models;

namespace webapi.Data
{
    public interface ITimeAttendanceRepository
    {
        TimeAttendance GetTimeAttendanceById(int attendaceId);
        List<TimeAttendance> GetTimeAttendanceByUserId(int userId);
        void AddTimeAttendance(TimeAttendance attendance);
        void UpdateTimeAttendance(TimeAttendance attendance);
        void DeleteTimeAttendance(int attendanceId);
    }
}

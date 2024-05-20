using BEDuo.Models;

namespace BEDuo.Data
{
    public class ScheduleData
    {
        public static List<Schedule> Schedules = new List<Schedule>
        {
            new Schedule()
            {
                Id=1,
                Title="A.P. Exams",
                StartDate= new DateTime(2023, 8, 2),
                EndDate= new DateTime(2024, 9, 2),
                UserID= 1,
                IsPublic= true
            },
            new Schedule()
            {
                Id=2,
                Title="Programming",
                StartDate= new DateTime(2023, 8, 2),
                EndDate= new DateTime(2024, 9, 2),
                UserID= 1,
                IsPublic= false
            },
            new Schedule()
            {
                Id=3,
                Title="Music",
                StartDate= new DateTime(2023, 10, 2),
                EndDate= new DateTime(2024, 9, 2),
                UserID= 2,
                IsPublic= true
            }
        };
    }
}

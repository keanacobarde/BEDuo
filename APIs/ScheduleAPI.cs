using BEDuo.Models;

namespace BEDuo.APIs
{
    public class ScheduleAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/schedule/{user}", (BEDuoDbContext db, int userId) =>
            {
                try
                {
                    var allSchedulesAssociatedWithUser = from schedules in db.Schedules
                                                         where schedules.UserID == userId
                                                         select schedules;
                    return Results.Ok(allSchedulesAssociatedWithUser);
                }
                catch
                {
                    return Results.NotFound();
                }
            });

            app.MapGet("/schedule/{id}", (BEDuoDbContext db, int scheduleId) => {
                try
                {
                    var scheduleDetails = db.Schedules.FirstOrDefault(s => s.Id == scheduleId);
                    return Results.Ok(scheduleDetails);
                }
                catch
                {
                    return Results.NotFound();
                }
            });
        }
    }
}

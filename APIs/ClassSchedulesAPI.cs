using Microsoft.EntityFrameworkCore;
using BEDuo.DTO;

namespace BEDuo.APIs
{
    public class ClassSchedulesAPI
    {
        public static void Map(WebApplication app)
        {
            //ADDING CLASSES
            app.MapPost("/schedule/addClass", (BEDuoDbContext db, addRemoveClassDTO newClass) =>
            {
                var schedule = db.Schedules.Include(o => o.Classes).FirstOrDefault(o => o.Id == newClass.ScheduleId);

                if (schedule == null)
                {
                    return Results.NotFound("Schedule not found.");
                }

                var Class = db.Classes.Find(newClass.ClassId);

                if (Class == null)
                {
                    return Results.NotFound("Class not found.");
                }

                schedule.Classes.Add(Class);

                db.SaveChanges();

                return Results.Created($"/Schedules/addClass", newClass);
            });

            //REMOVING CLASSES
            app.MapPost("/schedule/removeClass", (BEDuoDbContext db, addRemoveClassDTO classToRemove) =>
            {
                var Schedule = db.Schedules.Include(o => o.Classes).FirstOrDefault(o => o.Id == classToRemove.ScheduleId);

                if (Schedule == null)
                {
                    return Results.NotFound("Schedule not found.");
                }

                var Class = db.Classes.Find(classToRemove.ClassId);

                if (Class == null)
                {
                    return Results.NotFound("Class not found.");
                }

                Schedule.Classes.Remove(Class);

                db.SaveChanges();

                return Results.Created($"/Schedules/removeClass", classToRemove);
            });;
        }
    }
}

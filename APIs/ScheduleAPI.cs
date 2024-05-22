using Microsoft.EntityFrameworkCore;
using BEDuo.Models;

namespace BEDuo.APIs;
    public class ScheduleAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/schedule", (BEDuoDbContext db, Schedule scheduleToAdd) => 
            {
                try
                {
                    db.Schedules.Add(scheduleToAdd);
                    return Results.Ok();
                }
                catch
                { 
                    return Results.NotFound();
                }
            });

            app.MapGet("/schedule/user/{userId}", (BEDuoDbContext db, int userId) =>
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

            app.MapGet("/schedule/public", (BEDuoDbContext db) => 
            {
                return db.Schedules.Where(s => s.IsPublic);
            });

            app.MapGet("/schedule/{id}", (BEDuoDbContext db, int id) => {
                try
                {
                    Schedule scheduleDetails = db.Schedules
                    .Include(s => s.Classes)
                    .FirstOrDefault(s => s.Id == id);
                    return Results.Ok(scheduleDetails);
                }
                catch
                {
                    return Results.NotFound();
                }
            });

            app.MapPatch("/schedule/{id}", (BEDuoDbContext db, int scheduleId, Schedule editedschedule) => {
                try
                {
                    var scheduleToEdit = db.Schedules.FirstOrDefault(s => s.Id == scheduleId);
                    if (scheduleToEdit == null)
                    {
                        return Results.NotFound();
                    }

                    if (editedschedule.Id != 0)
                    {
                        scheduleToEdit.Id = editedschedule.Id;
                    };

                    if (editedschedule.Title != null)
                    {
                        scheduleToEdit.Title = editedschedule.Title;
                    };

                    if (editedschedule.StartDate != default)
                    {
                        scheduleToEdit.StartDate = editedschedule.StartDate;
                    };

                    if (editedschedule.EndDate != default)
                    {
                        scheduleToEdit.EndDate = editedschedule.EndDate;
                    };

                    if (editedschedule.IsPublic != default)
                    {
                        scheduleToEdit.IsPublic = editedschedule.IsPublic;
                    };

                    if (editedschedule.UserID != 0)
                    {
                        scheduleToEdit.UserID = editedschedule.UserID;
                    };
                    return Results.Ok(scheduleToEdit);
                }
                catch
                {
                    return Results.NotFound();
                }
            });

            app.MapDelete("/schedule/{scheduleId}", (BEDuoDbContext db, int scheduleId) =>
            {
                Schedule scheduleToDelete = db.Schedules.FirstOrDefault(c => c.Id == scheduleId);
                if (scheduleToDelete == null)
                {
                    return Results.NotFound();
                }
                db.Schedules.Remove(scheduleToDelete);
                db.SaveChanges();
                return Results.Ok(db.Schedules);
            });

        }

    }


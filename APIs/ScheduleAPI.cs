using BEDuo.Models;

namespace BEDuo.APIs;
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

            app.MapDelete("/schedules/{scheduleId}", (BEDuoDbContext db, int scheduleId) =>
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


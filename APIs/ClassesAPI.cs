using BEDuo.Models;

namespace BEDuo.APIs
{
    public class ClassesAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/classes/{user}", (BEDuoDbContext db, int userId) =>
            {
                try
                {
                    var allClassesAssociatedWithUser = from classes in db.Classes
                                                         where classes.UserId == userId
                                                         select classes;
                    return Results.Ok(allClassesAssociatedWithUser);
                }
                catch
                {
                    return Results.NotFound();
                }
            });

            app.MapPost("/classes", (BEDuoDbContext db, Classes classToAdd) => 
            { 
                db.Classes.Add(classToAdd);
                db.SaveChanges();
                return Results.Ok(db.Classes);
            });

            app.MapDelete("/classes/{classId}", (BEDuoDbContext db, int classId) => 
            {
                Classes classToDelete = db.Classes.FirstOrDefault(c => c.Id == classId);
                if (classToDelete == null)
                {
                    return Results.NotFound();
                }
                db.Classes.Remove(classToDelete);
                db.SaveChanges();
                return Results.Ok(db.Classes);
            });
        }
    }
}

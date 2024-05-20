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

            app.MapPatch("/classes/{id}", (BEDuoDbContext db, int classId, Classes editedClass) => 
            {
                try
                {
                    Classes classToEdit = db.Classes.FirstOrDefault(c => c.Id == classId);
                    if (classToEdit == null)
                    {
                        return Results.NotFound();
                    }

                    if (editedClass.Id != 0)
                    {
                        classToEdit.Id = editedClass.Id;
                    };

                    if (editedClass.Name != null)
                    {
                        classToEdit.Name = editedClass.Name;
                    };

                    if (editedClass.Description != null)
                    {
                        classToEdit.Description = editedClass.Description;
                    };

                    if (editedClass.University != null)
                    {
                        classToEdit.University = editedClass.University;
                    };

                    if (editedClass.StartDate != null)
                    {
                        classToEdit.StartDate = editedClass.StartDate;
                    };

                    if (editedClass.EndDate != null)
                    {
                        classToEdit.EndDate = editedClass.EndDate;
                    };

                    if (editedClass.isPublic != null)
                    {
                        classToEdit.isPublic = editedClass.isPublic;
                    };

                    if (editedClass.UserId != null)
                    {
                        classToEdit.UserId = editedClass.UserId;
                    };

                }
                catch
                {
                    return Results.NotFound();
                }
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

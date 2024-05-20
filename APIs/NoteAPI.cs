using BEDuo.Models;

namespace BEDuo.APIs
{
    public class NoteAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapDelete("/notes/{noteId}", (BEDuoDbContext db, int noteId) =>
            {
                Notes noteToDelete = db.Notes.FirstOrDefault(c => c.Id == noteId);
                if (noteToDelete == null)
                {
                    return Results.NotFound();
                }
                db.Notes.Remove(noteToDelete);
                db.SaveChanges();
                return Results.Ok(db.Notes);
            });

        }
    }
}

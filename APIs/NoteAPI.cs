using BEDuo.Models;

namespace BEDuo.APIs
{
    public class NoteAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/notes/{classId}", (BEDuoDbContext db, int classId) => 
            { 
                var classNotes = from notes in db.Notes
                                 where notes.ClassId == classId
                                 select notes;
                if (classNotes == null)
                { 
                    return Results.NotFound();
                }
                return Results.Ok(classNotes);
            });

            app.MapPost("/notes", (BEDuoDbContext db, Notes notesToAdd) => 
            {
                try
                {
                    db.Notes.Add(notesToAdd);
                    db.SaveChanges();
                    return Results.Ok(db.Notes.Where(n => n.ClassId == notesToAdd.ClassId));
                }
                catch { 
                    return Results.BadRequest();
                }
            });

            app.MapPatch("notes/{id}", (BEDuoDbContext db, int id, Notes editedNote) =>
            {
                try
                {
                    var noteToEdit = db.Notes.FirstOrDefault(n => n.ClassId == id);
                    if (noteToEdit == null)
                    {
                        return Results.BadRequest();
                    }

                    if (editedNote.ClassId != default)
                    {
                        noteToEdit.ClassId = editedNote.ClassId;
                    }

                    if (editedNote.DateCreated != default)
                    {
                        noteToEdit.DateCreated = editedNote.DateCreated;
                    }

                    if (editedNote.Description != null)
                    {
                        noteToEdit.Description = editedNote.Description; 
                    }

                    return Results.Ok(noteToEdit);
                }
                catch {
                    return Results.BadRequest();
                }
            });

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

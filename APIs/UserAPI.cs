using BEDuo.DTO;
using BEDuo.Models;

namespace BEDuo.APIs
{
    public class UserAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/checkuser", (BEDuoDbContext db, UserAuthDto userAuthDto) => 
            {
                var userUid = db.Users.SingleOrDefault(user => user.Uid == userAuthDto.Uid);

                if (userUid == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.Ok(userUid);
                }
            });

            app.MapGet("/users/{id}", (BEDuoDbContext db, int id) => {
                User user = db.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(user);
            });

            app.MapPost("/register", (BEDuoDbContext db, User user) =>
            {
                db.Users.Add(user);
                db.SaveChanges();
                return Results.Created($"/user/{user.Id}", user);
            });

            app.MapPatch("/users/{id}/edit", (BEDuoDbContext db, int id, User editedUser) =>
            {
                User userToEdit = db.Users.FirstOrDefault(u => u.Id == id);
                if (userToEdit == null)
                {
                    return Results.NotFound();
                }

                if (editedUser.Id != 0)
                { 
                    userToEdit.Id = editedUser.Id;
                };

                if (editedUser.Username != null)
                {
                    userToEdit.Username = editedUser.Username;
                };

                if (editedUser.UserImageURL != null)
                {
                    userToEdit.UserImageURL = editedUser.UserImageURL;
                };

                if (editedUser.University != null)
                {
                    userToEdit.University = editedUser.University;
                };

                if (editedUser.Uid != null)
                {
                    userToEdit.Uid = editedUser.Uid;
                };

                if (editedUser.Bio != null)
                {
                    userToEdit.Bio = editedUser.Bio;
                };

                db.SaveChanges();

                return Results.Ok(userToEdit);
            });

        }
    }
}

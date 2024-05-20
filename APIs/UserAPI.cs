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

        }
    }
}

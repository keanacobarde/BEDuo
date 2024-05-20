using BEDuo.Models;

namespace BEDuo.Data
{
    public class NoteData
    {
        public static List<Notes> Notes = new List<Notes>
        {
            new Notes
            {
                Id = 1,
                ClassId = 1,
                DateCreated = new DateTime(2024, 9, 2),
                Description = "Introduction to basic algebra. Today's class was really boring. -Caleb"
            },
            new Notes
            {
                Id = 2,
                ClassId = 1,
                DateCreated = new DateTime(2024, 9, 3),
                Description = "Went over Shakespeare today. A really interesting dude, I guess. Study session at 5 PM? - Mindy"
            },
            new Notes
            {
                Id = 3,
                ClassId = 3,
                DateCreated = new DateTime(2024, 9, 4),
                Description = "I do not know what I may appear to the world, but to myself I seem to have been only like a boy playing on the seashore, and diverting myself in now and then finding a smoother pebble or a prettier shell than ordinary, whilst the great ocean of truth lay all undiscovered before me. - Issac Newton"
            },
            new Notes
            {
                Id = 7,
                ClassId = 3,
                DateCreated = new DateTime(2024, 9, 4),
                Description = "Physics is hard. - Max"
            },
            new Notes
            {
                Id = 4,
                ClassId = 4,
                DateCreated = new DateTime(2024, 9, 5),
                Description = "The Renaissance and its impact on art."
            },
            new Notes
            {
                Id = 5,
                ClassId = 5,
                DateCreated = new DateTime(2024, 9, 6),
                Description = "Basic knife skills and safety."
            },
            new Notes
            {
                Id = 6,
                ClassId = 6,
                DateCreated = new DateTime(2024, 10, 2),
                Description = "Understanding camera settings and functions."
            }
        };
    }
}

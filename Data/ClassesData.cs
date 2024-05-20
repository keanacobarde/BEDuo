using BEDuo.Models;

namespace BEDuo.Data
{
    public class ClassesData
    {
        public static List<Classes> Classes = new List<Classes>
        {
            new Classes
            {
                Id = 1,
                Name = "Mathematics 101",
                Description = "An introductory course on basic mathematics.",
                StartDate = new DateTime(2024, 9, 1, 9, 0, 0),
                EndDate = new DateTime(2025, 5, 31, 10, 0, 0),
                isPublic = true,
                University="Western Governor's University",
                UserId = 1
            },
            new Classes
            {
                Id = 2,
                Name = "English Literature",
                Description = "A comprehensive study of English literature.",
                StartDate = new DateTime(2024, 9, 1, 11, 0, 0),
                EndDate = new DateTime(2025, 5, 31, 12, 30, 0),
                isPublic = true,
                University="Western Governor's University",
                UserId = 1
            },
            new Classes
            {
                Id = 3,
                Name = "Physics",
                Description = "An advanced course on classical and modern physics.",
                StartDate = new DateTime(2024, 9, 1, 14, 0, 0),
                EndDate = new DateTime(2025, 5, 31, 15, 30, 0),
                isPublic = true,
                University="Western Governor's University",
                UserId = 2
            },
            new Classes
            {
                Id = 4,
                Name = "Art History",
                Description = "An exploration of art history from ancient to modern times.",
                StartDate = new DateTime(2024, 9, 1, 16, 0, 0),
                EndDate = new DateTime(2025, 5, 31, 17, 30, 0),
                isPublic = true,
                UserId = 2
            },
            new Classes
            {
                Id = 5,
                Name = "Cooking Basics",
                Description = "Learn the basics of cooking, including recipes and techniques.",
                StartDate = new DateTime(2024, 9, 1, 18, 0, 0),
                EndDate = new DateTime(2024, 12, 15, 19, 30, 0),
                isPublic = true,
                UserId = 1
            },
            new Classes
            {
                Id = 6,
                Name = "Photography",
                Description = "A class on the fundamentals of photography.",
                StartDate = new DateTime(2024, 10, 1, 10, 0, 0),
                EndDate = new DateTime(2024, 12, 15, 11, 30, 0),
                isPublic = true,
                UserId = 1
            }
        };
    }
}

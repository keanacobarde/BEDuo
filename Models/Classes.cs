namespace BEDuo.Models
{
    public class Classes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool isPublic { get; set; }
        public int UserId { get; set; }
        public string? University { get; set; }
        public ICollection<Schedule>? Schedules { get; set; }
    }
}

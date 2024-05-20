namespace BEDuo.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserID { get; set; }
        public bool IsPublic { get; set; }
        public ICollection<Classes>? Classes { get; set; } 
    }
}

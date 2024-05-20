using Microsoft.EntityFrameworkCore;
using BEDuo.Models;
using BEDuo.Data;

namespace BEDuo
{
    public class BEDuoDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Notes> Notes { get; set; }

        public BEDuoDbContext(DbContextOptions<BEDuoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(UserData.Users);
            modelBuilder.Entity<Schedule>().HasData(ScheduleData.Schedules);
            modelBuilder.Entity<Classes>().HasData(ClassesData.Classes);
            modelBuilder.Entity<Notes>().HasData(NoteData.Notes);
        }
    }
}
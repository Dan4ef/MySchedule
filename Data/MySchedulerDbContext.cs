using Microsoft.EntityFrameworkCore;
using MyScheduler.Models;

namespace MyScheduler.Data
{
    public class MySchedulerDbContext : DbContext
    {
        public MySchedulerDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Pair> Pairs { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}


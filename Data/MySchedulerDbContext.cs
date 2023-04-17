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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //цей блок коду для з'єднання "один-до-багатьох"
            //ОДИН розклад з БАГАТЬМА парами
            builder.Entity<Schedule>()
                .HasMany(e => e.Pairs)
                .WithOne(e => e.Schedule)
                .HasForeignKey(pair => pair.ScheduleId);
        }

    }
}


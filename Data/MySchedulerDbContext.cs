using Microsoft.EntityFrameworkCore;
using MyScheduler.Models;

namespace MyScheduler.Data
{
    public class MySchedulerDbContext: DbContext
    {
        public MySchedulerDbContext(DbContextOptions options) : base(options) 
        {
        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Pair> Pairs { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

       // public MySchedulerDbContext(DbContextOptions<MySchedulerDbContext> options) { }//тут мали б бути опції
                                                                                       //але які

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);

            //цей блок коду для з'єднання "один-до-багатьох"
            //ОДИН розклад з БАГАТЬМА парами
            builder.Entity<Schedule>()
                .HasMany<Pair>(schedule => schedule.scheduleItems)
                .WithOne(pair => pair.Schedule)
                .HasForeignKey(pair => pair.ScheduleId);

            //UPDATE 13.04
            //в обидві сторони треба прописувати зв'язок щоб "підтягувалось" для обох випадків перегляду
            //це не єдина причина чому не працювало, але це важливо
            //для кожного one-to-one треба так само зробити і зробити міграцію
            //-> NuGet Package Console
            //-> Add-Migration "..."
            //-> Update-Database 
            builder.Entity<Schedule>()
                .HasOne<Group>(schedule => schedule.Group)
                .WithOne(group => group.GroupSchedule)
                .HasForeignKey<Group>(group => group.GroupScheduleId);
            
            //UPDATE END

            //один до одного
            //одній групі один розклад
            builder.Entity<Group>()
                .HasOne<Schedule>(schedule => schedule.GroupSchedule)
                //група має один розклад, де розклад вказаний по GroupSchedule
                .WithOne(group => group.Group)
                //де кожній групі відновідає група вказана по Group
                .HasForeignKey<Schedule>(group => group.GroupId);
            //має зовнішній ключ GroupId 

            builder.Entity<Pair>()
                .HasOne<Subject>(pair => pair.Subject)
                .WithMany(subject => subject.SubjectsOfPairs)
                .HasForeignKey(pair => pair.SubjectId);

            //ключі є
            //найстрашніше Багато до багатьох
            //одни викладач може вести багато предметів
            //так і один предмет ведуть різні викладачі 
            builder.Entity<TeachersSubjects>()
                .HasKey(ts => new { ts.TeacherId, ts.SubjectId });
        }
    }
}

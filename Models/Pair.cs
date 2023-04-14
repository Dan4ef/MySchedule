namespace MyScheduler.Models
{
    public class Pair
    {
        public int Id { get; set; }
        
        public string DayOfWeek { get; set; }
        public string Time { get; set; }
        //
        public int? SubjectId { get; set; }
        public Subject? Subject { get; set; }

        //
        public int? ScheduleId { get; set; }
        public Schedule? Schedule { get; set; }
        //
    }
}

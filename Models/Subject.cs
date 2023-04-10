namespace MyScheduler.Models
{
    public class Subject
    {
        public Guid  Id { get; set; } 
        public string Name { get; set; }
        public string Place { get; set; }
        public int TeacherId { get; set; }
    }
}

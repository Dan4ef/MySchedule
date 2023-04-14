namespace MyScheduler.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<TeachersSubjects> TeachersSubjects { get; set; }
    }
}

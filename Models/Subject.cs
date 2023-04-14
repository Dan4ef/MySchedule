namespace MyScheduler.Models
{
    public class Subject
    {
        public int  Id { get; set; } 
        public string Name { get; set; }
        public string Place { get; set; }
        
        public IList<TeachersSubjects> TeachersSubjects { get; set; }

        public ICollection<Pair> SubjectsOfPairs { get; set; }
    }
}

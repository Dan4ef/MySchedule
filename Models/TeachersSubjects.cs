namespace MyScheduler.Models
{
    public class TeachersSubjects
    {
        public int TeachersSubjectId { get; set; }//окремо для цієї таблиці
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int SubjectId { get; set; }  

        public Subject Subject { get; set; }


    }
}

namespace MyScheduler.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        
        public string Token { get; set; }

        public int? GroupId { get; set; }//посилаємось на GroupId - записане в полі id об'єкту класу Group
        public Group? Group { get; set; }
        
        //навігаційна властивість - список пар, в одному розкладі багато пар - один до багатьох
        public ICollection<Pair> scheduleItems { get; set; }


    }
}

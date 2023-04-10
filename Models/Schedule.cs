namespace MyScheduler.Models
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public int GroupId { get; set; }
        public string Days { get; set; }
        /*????
        class Schedule(object):
        tablename = "schedules"
        def __init__(self, groupId, days):
        self.id = str(uuid.uuid4())
        self.groupId = groupId
        self.days = days */

    }
}

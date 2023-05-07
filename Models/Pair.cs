using Microsoft.Build.Framework;

namespace MyScheduler.Models
{
    public class Pair
    {
        public Guid Id { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        [Required]
        public string Time { get; set; }
    }
}

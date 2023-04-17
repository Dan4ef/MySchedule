using Microsoft.Build.Framework;

namespace MyScheduler.Models
{
    public class Teacher
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

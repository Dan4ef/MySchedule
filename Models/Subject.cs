using Microsoft.Build.Framework;

namespace MyScheduler.Models
{
    public class Subject
    {
        public Guid  Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        public Guid TeacherId { get; set; }
    }
}

using Microsoft.Build.Framework;

namespace MyScheduler.Models
{
    public class Group
    {
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}

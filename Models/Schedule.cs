using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;

namespace MyScheduler.Models
{
    [Keyless]
    public class Day
    {
        [Required]
        public List<String> day { get; set; }
    }

    public class Schedule
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }

        [NotMapped]
        public List<Day> Days { get; set; }
    }
}

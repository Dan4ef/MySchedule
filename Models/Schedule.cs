using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;

namespace MyScheduler.Models
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }

        [Required]
        public string Days { get; set; }

        public List<Pair> Pairs { get; }
    }
}

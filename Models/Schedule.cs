using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyScheduler.Models
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public string Days { get; set; }
    }
}

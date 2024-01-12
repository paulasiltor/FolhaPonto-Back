using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaPonto.Domain.Models
{
    public class TimeTrackers
    {
        [Key]
        public Guid TimeTrackersId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [StringLength(200)]
        public string TimeZoneId { get; set; }
        public Tasks Tasks { get; set; }
        [Required]
        public Guid TasksId { get; set; }
        [Required]
        public Collaborators Collaborators { get; set; }
        public Guid CollaboratorsId { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdateAt { get; set; }
        [Required]
        public DateTime DeleteAt { get; set; }
    }
}


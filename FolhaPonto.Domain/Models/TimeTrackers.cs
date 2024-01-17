using System.ComponentModel.DataAnnotations;

namespace FolhaPonto.Domain.Models
{
    public class TimeTrackers : BaseEntity
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
        public Collaborators? Collaborators { get; set; }
        public Guid? CollaboratorsId { get; set; }
    }
}


using System.ComponentModel.DataAnnotations;

namespace FolhaPonto.Domain.Models
{
    public class Projects
    {
        [Key]
        public Guid ProjectsId { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdateAt { get; set; }
        [Required]
        public DateTime DeleteAt { get; set; }
    }   
}

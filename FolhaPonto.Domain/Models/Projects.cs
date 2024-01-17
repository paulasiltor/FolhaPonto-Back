using System.ComponentModel.DataAnnotations;

namespace FolhaPonto.Domain.Models
{
    public class Projects : BaseEntity
    {
        [Key]
        public Guid ProjectsId { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
    }   
}

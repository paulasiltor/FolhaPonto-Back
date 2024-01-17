using System.ComponentModel.DataAnnotations;

namespace FolhaPonto.Domain.Models
{
    public class Collaborators : BaseEntity
    {
        [Key]
        public Guid CollaboratorsId { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
    }
}

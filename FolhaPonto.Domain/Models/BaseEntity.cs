using System.ComponentModel.DataAnnotations;

namespace FolhaPonto.Domain.Models
{
    public class BaseEntity
    {
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdateAt { get; set; }
        public DateTime? DeleteAt { get; set; }
    }
}

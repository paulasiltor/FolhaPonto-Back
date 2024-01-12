using System.ComponentModel.DataAnnotations;

namespace FolhaPonto.Domain.Models
{
    public class Users
    {
        [Key]
        public Guid UsersId { get; set; }
        [Required]
        [StringLength(250)]
        public string UserName { get; set; }
        [Required]
        [StringLength(512)]
        public string Password { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdateAt { get; set; }
        [Required]
        public DateTime DeleteAt { get; set; }
    }
}

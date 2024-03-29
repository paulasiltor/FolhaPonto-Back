﻿using System.ComponentModel.DataAnnotations;

namespace FolhaPonto.Domain.Models
{
    public class Tasks : BaseEntity
    {
        [Key]
        public Guid TasksId { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public Projects Projects { get; set; }
        [Required]
        public Guid ProjectsId { get; set; }

    }
}

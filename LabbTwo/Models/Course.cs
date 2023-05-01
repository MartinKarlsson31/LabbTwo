﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LabbTwo.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; } = 0;
        [Required]
        [StringLength(50)]
        public string CourseName { get; set; } = default!;
        public virtual ICollection<SchoolConnection>? SchoolConnections { get; set; }
    }
}

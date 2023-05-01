using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LabbTwo.Models
{
    public class SchoolConnection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolConnectionId { get; set; }
        [ForeignKey("Courses")]
        public int FK_CourseId { get; set; }
        public virtual Course Courses { get; set; }

        [ForeignKey("Employees")]
        public int FK_EmployeeId { get; set; }
        public virtual Employee Employees { get; set; }

        [ForeignKey("Students")]
        public int FK_StudentId { get; set; }
        public virtual Student Students { get; set; }

        [ForeignKey("SchoolClasses")]
        public int FK_SchoolClassId { get; set; }
        public virtual SchoolClass SchoolClasses { get; set; }

    }
}

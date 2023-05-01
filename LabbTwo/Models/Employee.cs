using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LabbTwo.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; } = 0;
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = default!;
        [Required]
        [StringLength(30)]
        public string LastName { get; set; } = default!;
        public virtual ICollection<SchoolConnection>? SchoolConnections { get; set; }


    }
}

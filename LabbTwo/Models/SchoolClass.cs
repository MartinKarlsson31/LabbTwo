using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LabbTwo.Models
{
    public class SchoolClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolClassId { get; set; } = 0;
        [Required]
        [StringLength(50)]
        public string SchoolClassName { get; set; } = default!;
        public virtual ICollection<SchoolConnection>? SchoolConnections { get; set; }

    }
}

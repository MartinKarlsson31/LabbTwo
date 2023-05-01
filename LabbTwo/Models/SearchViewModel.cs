using System.ComponentModel.DataAnnotations;

namespace LabbTwo.Models
{
    public class SearchViewModel
    {
        [Key]
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SchoolClassName { get; set; }
    }
}

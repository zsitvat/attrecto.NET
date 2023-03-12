using System.ComponentModel.DataAnnotations;

namespace Academy_2023.Data
{
    public class Course
    {
        [Required]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}

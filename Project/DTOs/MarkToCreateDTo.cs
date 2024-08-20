using System.ComponentModel.DataAnnotations;

namespace Project.DTOs
{
    public class MarkToCreateDTo
    {
        [Range(1, 10, ErrorMessage = "Value must be between 1 and 10.")]
        public int Value { get; set; }

        [Required(ErrorMessage = "DateGiven is required.")]
        public DateTime DateGiven { get; set; }

        [Required(ErrorMessage = "SubjectName is required.")]
        [MaxLength(100, ErrorMessage = "SubjectName cannot be longer than 100 characters.")]
        public string SubjectName { get; set; }
    }
}

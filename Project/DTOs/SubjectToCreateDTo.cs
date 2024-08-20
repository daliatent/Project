using System.ComponentModel.DataAnnotations;

namespace Project.DTOs
{
    public class SubjectToCreateDTo
    {
        [Required(ErrorMessage = "Subject id is required.")]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }
    }
}

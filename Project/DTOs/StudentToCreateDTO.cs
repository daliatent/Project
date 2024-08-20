using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Project.DTOs
{
    public class StudentToCreateDTO
    {
        [Required(ErrorMessage = "Student id is required.")]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        [MaxLength(100, ErrorMessage = "Surname cannot be longer than 100 characters.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(1, int.MaxValue)]
        public int Age { get; set; }
        public AddressToCreateDTo Address { get; set; } 
    }
}

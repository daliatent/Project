using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Project.DTOs
{
    public class AddressToCreateDTo
    {
        [Required(ErrorMessage = "Adreess id is required.")]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [MaxLength(100, ErrorMessage = "City cannot be longer than 100 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        [MaxLength(100, ErrorMessage = "Street cannot be longer than 100 characters.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Number is required.")]
        [Range(1, int.MaxValue)]
        public int Number { get; set; }
    }
}

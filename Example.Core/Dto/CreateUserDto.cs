using System.ComponentModel.DataAnnotations;

namespace Example.Core.Dto
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(256, ErrorMessage = "First Name can't be longer than 256 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(256, ErrorMessage = "Last Name can't be longer than 256 characters")]
        public string LastName { get; set; }
    }
}

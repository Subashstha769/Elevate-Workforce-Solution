using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WebLab2024.Models
{
    public class UserViewModel
    {
        [Required (ErrorMessage ="Full Name cannot be empty!")]

        // Public string? FullName {get;set;}       (Another method )
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage ="Email cannot be empty!"),
        EmailAddress(ErrorMessage ="Please enter valid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage ="Password cannot be empty!")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage ="User Name cannot be empty!")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage ="Phone Number cannot be empty!")]

        public double PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }

    }

}
using System.ComponentModel.DataAnnotations;

namespace PasswordHashing.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage ="UserName field is required!")]
        [StringLength(25, ErrorMessage = "UserName must have fewer character than 25")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password field is required!")]
        [StringLength(60)]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Email address field is required!")]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}

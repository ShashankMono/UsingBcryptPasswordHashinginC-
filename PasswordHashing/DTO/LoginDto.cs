using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PasswordHashing.DTO
{
    public class LoginDto
    {
        [Required(ErrorMessage = "UserName field is required!")]
        [StringLength(25, ErrorMessage = "UserName must have fewer character than 25")]
        public string UserName {  get; set; }
        [Required(ErrorMessage = "Password field is required!"), StringLength(10, ErrorMessage = "Password must have fewer character than 10"),PasswordPropertyText(true)]
        public string Password { get; set; }
    }

}

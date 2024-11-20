using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordHashing.DTO;
using PasswordHashing.Services;
using System.ComponentModel.DataAnnotations;

namespace PasswordHashing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {

        //I have used bycrpt in Automapper and services
        //For hashing we using  BCrypt.Net.BCrypt.EnhancedHashPassword(PasswordString, 13)
        // the second parameter represent the Iteration of the hash the range is till 800
        // the hash generated using 13 itteration is of 60 character
        // and not verify the password is same or not with the hash code we use 
        //BCrypt.Net.BCrypt.EnhancedVerify(user Password, database PasswordHash) this line gives boolean value
        private readonly IUserService _userService;
        public UserLoginController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        public IActionResult Register(UserDto user) {
            if (!ModelState.IsValid) {
                var errors = string.Join(';', ModelState
                    .Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }
            return Ok(_userService.RegisterUser(user));
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto log)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(';', ModelState
                    .Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }
            return Ok(_userService.LoginUser(log));
        }

    }
}

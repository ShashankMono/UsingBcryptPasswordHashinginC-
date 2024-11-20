using PasswordHashing.DTO;

namespace PasswordHashing.Services
{
    public interface IUserService
    {
        public Guid RegisterUser(UserDto user);
        public String LoginUser(LoginDto log);
    }
}

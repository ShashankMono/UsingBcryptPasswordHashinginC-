using AutoMapper;
using PasswordHashing.DTO;
using PasswordHashing.Exceptions;
using PasswordHashing.Models;
using PasswordHashing.Repository;

namespace PasswordHashing.Services
{
    public class UserService:IUserService
    {
        private readonly IRepository<User> _repo;
        private readonly IMapper _mapper;
        public UserService(IRepository<User> repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public string LoginUser(LoginDto log)
        {
            User user = _repo.GetAll().FirstOrDefault(u=>u.UserName == log.UserName);
            if (user == null)
                throw new UserNotFoundException("User not found!");

            var login = BCrypt.Net.BCrypt.EnhancedVerify(log.Password, user.PasswordHash);

            if (login)
                return "Succefully loggedIn!";

            return "Bad credential! Not loggedIn";
        }

        public Guid RegisterUser(UserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            _repo.Add(user);
            return user.Id;
        }
    }
}

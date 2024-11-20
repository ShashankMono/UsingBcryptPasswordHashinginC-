using Microsoft.EntityFrameworkCore;
using PasswordHashing.Models;

namespace PasswordHashing.Data
{
    public class UserContext:DbContext
    {
        public DbSet<User> users { get; set; }
        public UserContext(DbContextOptions option):base(option)
        {
            
        }
    }
}

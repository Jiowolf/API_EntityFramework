using API_EntityFramework.Data;
using API_EntityFramework.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_EntityFramework.services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
    }

    public class UserService(ContextDatabase context) : IUserService
    {
        private readonly ContextDatabase _context = context;

        public async Task<IEnumerable<User>> GetUsers()
        {
            IEnumerable<User> users = await _context.Users.ToListAsync();
            return users;
        }
    }
}

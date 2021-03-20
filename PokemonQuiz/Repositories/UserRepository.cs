using Microsoft.EntityFrameworkCore;
using PokemonQuiz.Data;
using PokemonQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonQuiz.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected DatabaseContext _context;
        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(int userId)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId);
        }
        public async Task<User> GetUser(string username)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User> AddUser(User user)
        {
            //encrypt user password
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async void UpdateExpectedAnswer(int userId, string expectedAnswer)
        {
            var user = new User { UserId = userId, ExpectedAnswer = expectedAnswer };
            _context.Entry(user).Property(u => u.ExpectedAnswer).IsModified = true;
            _context.SaveChanges();
        }

        public async Task UpdateCorrectAnswers(User user)
        {
            user.CorrectAnswers++;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateIncorrectAnswers(User user)
        {
            user.IncorrectAnswers++;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }
    }
}

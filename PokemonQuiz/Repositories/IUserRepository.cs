using PokemonQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonQuiz.Repositories
{
    public interface IUserRepository
    {
        public Task<User> GetUser(string username);

        public Task<User> GetUser(int userId);
        public Task<User> AddUser(User user);
        public void UpdateExpectedAnswer(int userId, string expectedAnswer);
        public Task UpdateIncorrectAnswers(User user);
        public Task UpdateCorrectAnswers(User user);

        public Task<IEnumerable<User>> GetAll();
    }
}

using PokemonQuiz.Models;
using Microsoft.EntityFrameworkCore;

namespace PokemonQuiz.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Pokemon> Pokemon { get; set; }
    }
}
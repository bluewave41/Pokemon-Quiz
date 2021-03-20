using PokemonQuiz.Data;
using PokemonQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonQuiz.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        protected DatabaseContext _context;
        public PokemonRepository(DatabaseContext context)
        {
            _context = context;
        }
        public Pokemon GetRandomPokemon()
        {
            return _context.Pokemon.OrderBy(p => Guid.NewGuid()).First();
        }
    }
}

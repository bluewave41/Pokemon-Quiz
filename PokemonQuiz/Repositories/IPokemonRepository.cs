using PokemonQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonQuiz.Repositories
{
    public interface IPokemonRepository
    {
        public Pokemon GetRandomPokemon();
    }
}

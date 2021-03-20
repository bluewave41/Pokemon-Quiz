using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonQuiz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokemonQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IUserRepository _userRepository;

        private enum QuestionTypes
        {
            PokedexId,
            PokedexName,
            Types,
            EvolutionMethod,
            NextEvolution
        }

        public QuestionController(IPokemonRepository pokemonRepository, IUserRepository userRepository)
        {
            _pokemonRepository = pokemonRepository;
            _userRepository = userRepository;
        }

        // GET: api/<QuestionController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int? checkId = HttpContext.Session.GetInt32("userId");

            if(checkId == null)
            {
                return Unauthorized();
            }

            int userId = (int)checkId;
            
            //TODO: make sure user has quiz going

            //get a pokemon
            var pokemon = _pokemonRepository.GetRandomPokemon();
            string displayName = pokemon.DisplayName;

            //get a question type
            var random = new Random();
            var enums = Enum.GetValues(typeof(QuestionTypes));
            switch(enums.GetValue(random.Next(enums.Length)))
            {
                case QuestionTypes.PokedexId:
                    _userRepository.UpdateExpectedAnswer(userId, pokemon.PokemonId.ToString());
                    return Ok($"What is the Pokedex ID of {displayName}?");
                case QuestionTypes.PokedexName:
                    _userRepository.UpdateExpectedAnswer(userId, pokemon.Name);
                    return Ok($"What is the name of the Pokemon #{pokemon.PokemonId}?");
                case QuestionTypes.Types:
                    if(pokemon.Type2 != null)
                    {
                        _userRepository.UpdateExpectedAnswer(userId, pokemon.Type1 + " " + pokemon.Type2);
                    }
                    else
                    {
                        _userRepository.UpdateExpectedAnswer(userId, pokemon.Type1);

                    }
                    return Ok($"What type or types is {displayName}?");
                case QuestionTypes.EvolutionMethod:
                    if(pokemon.EvolutionMethod != null)
                    {
                        _userRepository.UpdateExpectedAnswer(userId, pokemon.EvolutionMethod);
                    }
                    else
                    {
                        _userRepository.UpdateExpectedAnswer(userId, "0");
                    }
                    return Ok($"How or at what level does {displayName} evolve?");
                case QuestionTypes.NextEvolution:
                    if(pokemon.EvolutionName != null)
                    {
                        _userRepository.UpdateExpectedAnswer(userId, pokemon.EvolutionName);
                    }
                    else
                    {
                        _userRepository.UpdateExpectedAnswer(userId, "none");
                    }
                    
                    return Ok($"What is the next evolution of {displayName}?");
            }
            return null;
        }

        // GET api/<QuestionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<QuestionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<QuestionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

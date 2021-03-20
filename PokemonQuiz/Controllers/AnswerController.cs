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
    public class AnswerController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AnswerController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //GET api/<AnswerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int? checkId = HttpContext.Session.GetInt32("userId");
            if (checkId == null)
            {
                return Unauthorized();
            }

            int userId = (int)checkId;

            var user = await _userRepository.GetUser(userId);

            if(!user.Admin)
            {
                return Unauthorized();
            }

            return Ok(user.ExpectedAnswer);
        }

        // POST api/<AnswerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            int? checkId = HttpContext.Session.GetInt32("userId");
            if (checkId == null)
            {
                return Unauthorized();
            }

            int userId = (int)checkId;

            var user = await _userRepository.GetUser(userId);

            if(user.ExpectedAnswer == null)
            {
                return BadRequest("You haven't started a quiz.");
            }

            string correctAnswer = char.ToUpper(user.ExpectedAnswer[0]) + user.ExpectedAnswer.Substring(1);

            //pokemon has 2 types
            if(correctAnswer.Contains(" "))
            {
                string[] splitUserAnswer = value.ToLower().Split(" ");
                string[] splitAnswer = user.ExpectedAnswer.ToLower().Split(" ");
                if(splitUserAnswer.Except(splitAnswer).Any())
                {
                    return Ok(new Answer { Correct = false, CorrectAnswer = correctAnswer, CorrectAnswers = user.CorrectAnswers, IncorrectAnswers = user.IncorrectAnswers });
                }
                else
                {
                    return Ok(new Answer { Correct = true, CorrectAnswer = correctAnswer, CorrectAnswers = user.CorrectAnswers, IncorrectAnswers = user.IncorrectAnswers });
                }
            }

            //think about 2 types
            if (user.ExpectedAnswer.ToLower() == value.ToLower())
            {
                await _userRepository.UpdateCorrectAnswers(user);
                return Ok(new Answer { Correct = true, CorrectAnswer = correctAnswer, CorrectAnswers = user.CorrectAnswers, IncorrectAnswers = user.IncorrectAnswers });
            }
            else
            {
                await _userRepository.UpdateIncorrectAnswers(user);
                return Ok(new Answer { Correct = false, CorrectAnswer = correctAnswer, CorrectAnswers = user.CorrectAnswers, IncorrectAnswers = user.IncorrectAnswers });
            }
        }
    }

    public class Answer
    {
        public bool Correct { get; set; }
        public string CorrectAnswer { get; set; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
    }
}
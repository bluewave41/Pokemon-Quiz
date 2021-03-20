using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PokemonQuiz.Data;
using PokemonQuiz.Models;
using PokemonQuiz.Repositories;

namespace PokemonQuiz.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Login([FromBody] User user)
        {
            var foundUser = await _userRepository.GetUser(user.Username);
            user.HashPassword();
            
            if(foundUser.Password == user.Password)
            {
                HttpContext.Session.SetInt32("userId", foundUser.UserId);
                HttpContext.Session.SetString("username", foundUser.Username);
                return Ok("Success");
            }
            else
            {
                return Unauthorized("Username or password are incorrect.");
            }
        }

        public async Task<IActionResult> Register([FromBody] User user)
        {
            //does that username exist already?
            var foundUser = await _userRepository.GetUser(user.Username);

            if(foundUser != null)
            {
                return Conflict("That username is already taken.");
            }

            user.HashPassword();

            await _userRepository.AddUser(user);

            return Ok("Account created successfully. You can now login.");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return Ok();
        }
    }
}

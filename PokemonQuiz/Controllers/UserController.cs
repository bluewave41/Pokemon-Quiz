using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonQuiz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonQuiz.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetAdmin()
        {
            int? checkId = HttpContext.Session.GetInt32("userId");
            if(checkId == null)
            {
                return Unauthorized();
            }

            var user = await _userRepository.GetUser((int)checkId);
            return Ok(user.Admin);
        }

        public ActionResult GetUsername()
        {
            string username = HttpContext.Session.GetString("username");
            return Ok(username);
        }

        public async Task<ActionResult> Get()
        {
            return Ok(await _userRepository.GetAll());
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

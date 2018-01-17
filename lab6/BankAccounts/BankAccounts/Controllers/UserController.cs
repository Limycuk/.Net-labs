using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccountsDB;
using BankAccountsDB.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAccounts.Controllers
{
    public class UserController : Controller
    {
        private readonly IGenericRepository<User> _userRepository;
        public UserController(IGenericRepository<User> userRepository) {
            _userRepository = userRepository;
        }
        // GET: User
        public ActionResult Index()
        {
            List<User> Users = _userRepository.GetAll().ToList();
            ViewData["Users"] = Users;
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                User user = new User();
                user.FirstName = collection["FirstName"].ToString();
                user.LastName = collection["LastName"].ToString();
                user.Email = collection["Email"].ToString();
                await _userRepository.Create(user);
                await _userRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
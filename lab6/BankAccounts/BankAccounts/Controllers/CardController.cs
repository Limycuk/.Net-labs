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
    public class CardController : Controller
    {
        private readonly IGenericRepository<Card> _cardRepository;
        public CardController(IGenericRepository<Card> cardRepository)
        {
            _cardRepository = cardRepository;
        }
        // GET: User
        public ActionResult Index()
        {
            List<Card> Cards = _cardRepository.GetAll().ToList();
            ViewData["Cards"] = Cards;
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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Card card = new Card();
                card.Name = collection["Name"].ToString();
                card.BalanceCoefficient = Convert.ToInt32(collection["BalanceCoefficient"].ToString());
                card.ProfitCoefficient = Convert.ToInt32(collection["ProfitCoefficient"].ToString());
                _cardRepository.Create(card);
                _cardRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
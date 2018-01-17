using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccountsDB;
using BankAccountsDB.Entities;
using BankNumberGenerator;
using BonusCalculator.js;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankAccounts.Controllers
{
    public class BankAccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Card> _cardRepository;
        private readonly IBankAccountBonusCalculator _bonusCalculator;
        private readonly IRandomGenerator _randomGenerator;
        public BankAccountController(
            IAccountRepository accountRepository,
            IGenericRepository<User> userRepository,
            IGenericRepository<Card> cardRepository,
            IRandomGenerator randomGenerator,
            IBankAccountBonusCalculator bonusCalculator)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
            _cardRepository = cardRepository;
            _randomGenerator = randomGenerator;
            _bonusCalculator = bonusCalculator;
        }
        // GET: BankAccount
        public ActionResult Index()
        {
            List<Account> BankAccounts = _accountRepository.GetAll().ToList();
            ViewData["BankAccounts"] = BankAccounts;
            return View();
        }

        // GET: BankAccount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BankAccount/Create
        public ActionResult Create()
        {
            ViewData["AccountNumber"] = _randomGenerator.GenerateNumber(16);
            ViewData["Users"] = new SelectList(_userRepository.GetAll().ToList(), "Id", "Email");
            ViewData["Cards"] = new SelectList(_cardRepository.GetAll().ToList(), "Id", "Name");
            return View();
        }

        // POST: BankAccount/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                Account account = new Account();
                account.Number = collection["Number"].ToString();
                account.Amount = Convert.ToInt32(collection["Amount"].ToString());
                account.CardId = Convert.ToInt32(collection["Card"]);
                account.UserId = Convert.ToInt32(collection["User"]);
                Card card =  _cardRepository.GetById(account.CardId).Result;
                account.Points = _bonusCalculator.CalculateRefill(account.Amount, card.BalanceCoefficient, 0, card.ProfitCoefficient);
                await _accountRepository.Create(account);
                await _accountRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BankAccount/Edit/5
        public ActionResult ManageMoney(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        // POST: BankAccount/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ManageMoney(int id, IFormCollection collection)
        {
            try
            {
                int accountId = Convert.ToInt32(collection["Id"].ToString());
                int amount = Convert.ToInt32(collection["Amount"].ToString());
                Account account = await _accountRepository.GetById(accountId);
                if (amount > 0)
                {
                    account.Points += _bonusCalculator.CalculateRefill(account.Amount, account.Card.BalanceCoefficient, amount, account.Card.ProfitCoefficient);
                } else
                {
                    account.Points += _bonusCalculator.CalculateDebit(account.Amount, account.Card.BalanceCoefficient, amount, account.Card.ProfitCoefficient);
                }

                await _accountRepository.Update(account);
                await _accountRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BankAccount/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            await _accountRepository.Delete(id);
            await _accountRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
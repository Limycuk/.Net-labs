using BankAccountsDB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountsDB
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        IQueryable<Account> GetAll();
        Task<Account> GetById(int id);
    }
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<Account> GetAll()
        {
            return _dbContext.Set<Account>().AsNoTracking().Include("User").Include("Card");
        }
        public async Task<Account> GetById(int id)
        {
            return await _dbContext.Set<Account>().AsNoTracking().Include("Card").FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}

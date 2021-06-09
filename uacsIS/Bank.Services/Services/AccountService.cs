using AutoMapper;
using Bank.Data;
using Bank.Model.Models.Account;
using Bank.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services.Services
{
    public class AccountService
    
           : IAccountService
    {
        private readonly BankDbContext _context;
        private readonly IMapper _mapper;

        public AccountService(BankDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountModelBase>> Get()
        {
            var matches = await _context.Accounts.ToListAsync();
            return _mapper.Map<IEnumerable<AccountModelBase>>(matches);
        }


        public async Task<AccountModelBase> Insert(AccountCreateModel model)
        {
            var entity = _mapper.Map<Account>(model);

            await _context.Accounts.AddAsync(entity);
            await SaveAsync();

            return _mapper.Map<AccountModelBase>(entity);
        }

        public async Task<AccountModelBase> Update(AccountUpdateModel model)
        {
            var entity = _mapper.Map<Account>(model);

            _context.Accounts.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            await SaveAsync();

            return _mapper.Map<AccountModelBase>(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(entity);
            return await SaveAsync() > 0;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

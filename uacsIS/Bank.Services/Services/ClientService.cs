using AutoMapper;
using Bank.Data;
using Bank.Model.Models.Client;
using Bank.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services.Services
{
    public class ClientService

           : IClientService
    {
        private readonly BankDbContext _context;
        private readonly IMapper _mapper;

        public ClientService(BankDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientModelBase>> Get()
        {
            var matches = await _context.Accounts.ToListAsync();
            return _mapper.Map<IEnumerable<ClientModelBase>>(matches);
        }


        public async Task<ClientModelBase> Insert(ClientCreateModel model)
        {
            var entity = _mapper.Map<Client>(model);

            await _context.Accounts.AddAsync(entity);
            await SaveAsync();

            return _mapper.Map<ClientModelBase>(entity);
        }

        public async Task<ClientModelBase> Update(ClientUpdateModel model)
        {
            var entity = _mapper.Map<Client>(model);

            _context.Clients.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            await SaveAsync();

            return _mapper.Map<ClientModelBase>(entity);
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

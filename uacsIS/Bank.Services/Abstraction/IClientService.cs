using System;
using System.Collections.Generic;
using Bank.Model.Models.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services.Abstraction
{
    public interface IClientService
    {
        Task<IEnumerable<ClientModelBase>> Get();
        Task<ClientModelBase> Insert(ClientCreateModel model);
        Task<ClientModelBase> Update(ClientUpdateModel model);
        Task<bool> Delete(int id);
    }
}

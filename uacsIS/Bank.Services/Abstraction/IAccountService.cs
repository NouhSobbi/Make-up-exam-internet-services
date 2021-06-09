using System;
using Bank.Model.Models.Account;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services.Abstraction
{
   public interface IAccountService
    {
        Task<IEnumerable<AccountModelBase>> Get();
        Task<AccountModelBase> Insert(AccountCreateModel model);
        Task<AccountModelBase> Update(AccountUpdateModel model);
        Task<bool> Delete(int id);
    }
}

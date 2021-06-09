using AutoMapper;
using Bank.Data.Entities;
using Bank.Model.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model.Profiles
{

    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountModelBase>().ReverseMap();
            CreateMap<AccountCreateModel, Account>();
            CreateMap<AccountUpdateModel, Account>();

        }
    }
}

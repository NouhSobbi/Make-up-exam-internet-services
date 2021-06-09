using AutoMapper;
using Bank.Services.Abstraction;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bank.Test.Services
{
    [TestFixture]
   public class AccountServiceTests
    {
        
       
            private IAccountService _service;
            private readonly IMapper _mapper;

            public AccountServiceTests()
            {
                var config = new MapperConfiguration(mc =>
                {
                    mc.AddMaps("Bank.Data");
                });
                _mapper = config.CreateMapper();
            }
        }
}

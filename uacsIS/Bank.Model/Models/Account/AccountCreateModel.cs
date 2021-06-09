using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model.Models.Account
{
    public class AccountCreateModel
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
    }
}

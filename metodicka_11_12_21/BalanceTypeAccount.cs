using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metodicka_11_12_21
{
    class BalanceTypeAccount : Factory
    {
        decimal balance;
        BankAccount.accountType type;
        public BalanceTypeAccount(decimal balance, BankAccount.accountType type) : base()
        {
            this.balance = balance;
            this.type = type;
        }
        public override BankAccount CreateAccount()
        {
            BankAccount acc = new BankAccount(balance, type);
            table.Add(acc.GetID(), acc);
            return acc;
        }
    }
}

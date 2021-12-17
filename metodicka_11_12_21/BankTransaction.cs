using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metodicka_11_12_21
{
    class BankTransaction
    {
        public decimal amount { get; private set; }
        public DateTime time { get; private set; }
        public BankTransaction(decimal amount)
        {
            this.amount = amount;
            time = DateTime.Now;
        }
        public string GetInfo()
        {
            return $"{time} {amount}\n";
        }
    }
}

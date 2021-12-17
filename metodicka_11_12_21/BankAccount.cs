using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace metodicka_11_12_21
{
    [DevelopementInfo("Данил", "Кфу")]
    class BankAccount
    {
        System.Collections.Queue transactions = new System.Collections.Queue();
        [Conditional("DEBUG_ACCOUNT")]
        public void DumpToScreen()
        {
            Console.WriteLine($"ID Аккаунта {ID}");
            Console.WriteLine($"Кол-во хранящихся транзакций:{transactions.Count}");
        }
        public enum accountType { current, saving }
        private static int id = 100;
        public decimal balance { get; private set; }
        public accountType type { get; private set; }
        public int ID { get; private set; }
        internal BankAccount()
        {
            ID = id;
            balance = 0;
            type = accountType.current;
            AddID();
            Console.Clear();
            Console.WriteLine("Счёт открыт. Его номер: {0}", GetID());
        }
        internal BankAccount(decimal balance)
        {
            ID = id;
            this.balance = balance;
            type = accountType.current;
            AddID();
            Console.Clear();
            Console.WriteLine("Счёт открыт. Его номер: {0}", GetID());
        }
        internal BankAccount(accountType type)
        {
            ID = id;
            this.balance = 0;
            this.type = type;
            AddID();
            Console.Clear();
            Console.WriteLine("Счёт открыт. Его номер: {0}", GetID());
        }
        internal BankAccount(decimal balance, accountType type)
        {
            ID = id;
            this.balance = balance;
            this.type = type;
            AddID();
            Console.Clear();
            Console.WriteLine("Счёт открыт. Его номер: {0}", GetID());
        }
        public void SwitchType()
        {
            if (type == accountType.current)
            {
                type = accountType.saving;
            }
            else
            {
                type = accountType.current;
            }
            Console.Clear();
            Console.WriteLine("Тип аккаунта изменен на " + type);
        }
        public void Deposite(decimal amount)
        {
            balance += amount;
            transactions.Enqueue(new BankTransaction(amount));
        }
        public void Withdraw(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                transactions.Enqueue(new BankTransaction((-1) * amount));
                Console.Clear();
                Console.WriteLine("Деньги выведены со счета");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Недостаточно средств");
            }
        }
        public void Trasfer(int a, int b, decimal amount, Dictionary<int, BankAccount> accounts)
        {
            if (accounts[a].GetBalance() >= amount)
            {
                accounts[a].Withdraw(amount);
                accounts[b].Deposite(amount);
                Console.Clear();
                Console.WriteLine("Деньги переведены");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Недостаточно средств для перевода");
            }
        }
        public void Dipose()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"transactions");
            using (FileStream fs = new FileStream($@"{path}\{ID}.txt", FileMode.Create))
            {
                foreach (var transaction in transactions)
                {
                    GC.SuppressFinalize(transaction);
                    BankTransaction t = (BankTransaction)transaction;
                    string output = t.GetInfo();
                    byte[] array = System.Text.Encoding.Default.GetBytes(output);
                    fs.Write(array, 0, array.Length);
                }
            }
        }
        public int GetID()
        {
            return ID;
        }
        public decimal GetBalance()
        {
            return balance;
        }
        public static int AddID()
        {
            return ++id;
        }

        public static bool operator !=(BankAccount accountOne, BankAccount accountTwo)
        {
            if (accountOne.ID.Equals(accountTwo.ID) && accountOne.type.Equals(accountTwo.type) && accountOne.balance.Equals(accountTwo.balance))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool operator ==(BankAccount accountOne, BankAccount accountTwo)
        {
            if (accountOne.ID.Equals(accountTwo.ID) && accountOne.type.Equals(accountTwo.type) && accountOne.balance.Equals(accountTwo.balance))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return $"Номер счета: {ID}\nТип счёта: {type}\nБаланс: {balance}";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

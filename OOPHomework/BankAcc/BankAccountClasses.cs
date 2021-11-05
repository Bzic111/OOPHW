using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPHomework
{
    class BankAccountClasses
    {
        public static void Run()
        {
            Random rnd = new Random(); rnd.Next(rnd.Next(rnd.Next()));
            int iter = rnd.Next(2, 6);
            NightmareAccount[] nmac = new NightmareAccount[iter];
            IAccount[] iAccs = new IAccount[iter];
            for (int i = 0; i < iter; i++)
            {
                if (i % 2 == 0) nmac[i] = new NightmareAccount(AccountType.Credit, rnd.Next(10_000, 50_000));
                else nmac[i] = new NightmareAccount(AccountType.Debit);
                iAccs[i] = nmac[i];
                nmac[i].Enrollment(rnd.Next(10_000, 15_000));
                if (i > 0) nmac[i].Transfer(nmac[i - 1], rnd.Next(7_000, 12_000));
            }
            foreach (var item in iAccs)
            {
                item.AccountInfo();
                if (item.GetAccType() == AccountType.Credit)
                    item.Withdraw(item.GetBalance() + (item.GetBalance() / 2));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPHomework
{
    static class BankAccountClasses
    {
        static void Run()
        {
            int iter = 4;
            LightAccount[] lac = new LightAccount[iter];
            NormalAccount[] nac = new NormalAccount[iter];
            HardAccount[] hac = new HardAccount[iter];
            NightmareAccount[] nmac = new NightmareAccount[iter];
            IAccount[] iAccs = new IAccount[iter * 4];

            for (int i = 0; i < iter; i++)
            {
                lac[i] = new LightAccount();
                lac[i].SetId(i + 1);

                if (i % 2 == 0)
                {
                    lac[i].SetAccType(AccountType.Credit);
                    nac[i] = new NormalAccount(AccountType.Credit);
                    hac[i] = new HardAccount(AccountType.Credit);
                    nmac[i] = new NightmareAccount(AccountType.Credit, (i + 100) * 100);
                }
                else
                {
                    lac[i].SetAccType(AccountType.Debit);
                    nac[i] = new NormalAccount(AccountType.Debit);
                    hac[i] = new HardAccount(AccountType.Debit);
                    nmac[i] = new NightmareAccount(AccountType.Debit);
                }
                lac[i].Enrollment((i + 100) * 100);
                nac[i].Enrollment((i + 100) * 101);
                hac[i].Enrollment((i + 100) * 102);
                nmac[i].Enrollment((i + 100) * 103);

                lac[i].Withdraw((decimal)Math.Pow(i + 10, 2));
                nac[i].Withdraw((decimal)Math.Pow(i + 10, 2));
                hac[i].Withdraw((decimal)Math.Pow(i + 10, 2));
                nmac[i].Withdraw((decimal)Math.Pow(i + 10, 2));
            }

            for (int j = 0, i = 0; i < iAccs.Length; j++, i += iter)
            {
                iAccs[i] = lac[j];
                iAccs[i + 1] = nac[j];
                iAccs[i + 2] = hac[j];
                iAccs[i + 3] = nmac[j];
            }

            foreach (var item in iAccs)
            {
                item.AccountInfo();
                if (item.GetAccType() == AccountType.Credit) item.SetLimit(item.GetBalance());
                Console.WriteLine();
            }

            nmac[0].Transfer(nmac[1], 25000);
            nmac[0].Transfer(nmac[1], 2500);
            for (int i = 0; i < iAccs.Length; i++)
                if (iAccs[i].GetAccType() == AccountType.Credit)
                    iAccs[i].Withdraw(iAccs[i].GetBalance() + (iAccs[i].GetBalance() / 2));
        }
    }
}

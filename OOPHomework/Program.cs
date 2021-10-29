using System;

namespace OOPHomework
{
    public enum AccountType
    {
        Debit,
        Credit
    }

    class Program
    {
        static void Main(string[] args)
        {
            int iter = 4;
            LightAccount[] lac = new LightAccount[iter];
            NormalAccount[] nac = new NormalAccount[iter];
            HardAccount[] hac = new HardAccount[iter];
            NightmareAccount[] nmac = new NightmareAccount[iter];

            for (int i = 0; i < iter; i++)
            {
                lac[i] = new LightAccount();
                lac[i].SetId(i);

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

            foreach (var item in lac) Console.WriteLine($"Account #: {item.GetId()}\t\tbalance : {item.GetBalance()}\t\tAccount Type : {item.GetAccType()}");
            foreach (var item in nac) Console.WriteLine($"Account #: {item.GetId()}\t\tbalance : {item.GetBalance()}\t\tAccount Type : {item.GetAccType()}");
            foreach (var item in hac) Console.WriteLine($"Account #: {item.GetId()}\t\tbalance : {item.GetBalance()}\t\tAccount Type : {item.GetAccType()}");
            foreach (var item in nmac)
            {
                string temp = "";
                if (item.AccType == AccountType.Credit)
                {
                    temp = $"\t\tCredit limit : {item._limit}";
                }
                Console.WriteLine($"Account #: {item.GetId()}\t\tbalance : {item.Balance}\t\tAccount Type : {item.AccType}{temp}");
            }
        }
    }
}

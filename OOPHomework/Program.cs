using System;

namespace OOPHomework
{
    class Program
    {
        public enum AccountType
        {
            Debit,
            Credit
        }
        class LightAccount
        {
            private int _id;
            private decimal _balance;
            private AccountType _accType;

            public void SetId(int id) => _id = id;
            public int GetId() => _id;
            public void Enrollment(decimal sum) => _balance += sum;
            public void Withdraw(decimal sum) => _balance -= sum;
            public decimal GetBalance() => _balance;
            public void SetAccType(AccountType accType) => _accType = accType;
            public AccountType GetAccType() => _accType;
        }

        static void Main(string[] args)
        {
            LightAccount la = new LightAccount();

            la.SetId(1);
            la.SetAccType(AccountType.Debit);
            la.Enrollment(1000);
            la.Withdraw(100);
            Console.WriteLine($"Account #: {la.GetId()}\nbalance : {la.GetBalance()}\nAccount Type : {la.GetAccType()}");
        }
    }
}

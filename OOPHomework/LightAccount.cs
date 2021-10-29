using System;

namespace OOPHomework
{
    class LightAccount
    {
        private int _id;
        private decimal _balance;
        private AccountType _accType;

        public void SetId(int id) => _id = id;
        public string GetId() => $"LA{_id.ToString("D8")}";
        public void Enrollment(decimal sum)
        {
            this._balance += sum;
            Console.WriteLine($"Acc : {GetId()}\tEnroll {sum} successful, total balance : {_balance}");
        }

        public void Withdraw(decimal sum)
        {
            this._balance -= sum;
            Console.WriteLine($"Acc : {GetId()}\tWithdraw {sum} successful, total balance : {_balance}");
        }

        public decimal GetBalance() => _balance;
        public void SetAccType(AccountType accType) => _accType = accType;
        public AccountType GetAccType() => _accType;
    }
}

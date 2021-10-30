using System;
namespace OOPHomework
{
    class NormalAccount
    {
        private static int counter = 0;
        private readonly int _id;
        private decimal _balance;
        private AccountType _accType;
        public NormalAccount(AccountType accType)
        {
            counter++;
            _id = counter;
            _accType = accType;
        }
        public void ChangeAccType(AccountType accType) => _accType = accType;
        public string GetId() => $"NA{_id.ToString("D8")}";
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
        public AccountType GetAccType() => _accType;
    }
}

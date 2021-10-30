using System;

namespace OOPHomework
{
    class NightmareAccount
    {
        private static int _counter { get; set; } = 0;
        private int Id { get; set; } = ++_counter;
        public decimal Balance { get; private set; }
        public AccountType AccType { get; private set; }
        public decimal _limit { get; private set; } = 0;
        public decimal arrears { get; private set; } = 0;
        public NightmareAccount() { }
        public NightmareAccount(decimal sum) : this() => Balance = sum;
        public NightmareAccount(AccountType accType, decimal limit = 0) : this((decimal)0)
        {
            AccType = accType;
            _limit = limit;
        }

        public void IncreaseLimit(decimal sum)
        {
            if (AccType == AccountType.Credit) _limit += sum;
            else Console.WriteLine($"Account type not support credit limit.");
        }
        public void DecreaseLimit(decimal sum)
        {
            if (_limit >= sum) _limit -= sum;
            else Console.WriteLine("Credit Limit to low");
        }
        public string GetId() => $"NMA{Id.ToString("D8")}";
        public void Enrollment(decimal sum)
        {
            Balance += sum;
            Console.WriteLine($"Acc : {GetId()}\tEnroll {sum} successful, total balance : {Balance}");
        }

        public void Withdraw(decimal sum)
        {
            if (Balance >= sum)
            {
                Balance -= sum;
                Console.WriteLine($"Acc : {GetId()}\tWithdraw {sum} successful, total balance : {Balance}");
            }
            else if (Balance < sum && AccType == AccountType.Credit)
            {
                if (Balance + _limit >= sum)
                {
                    Balance = 0;
                    _limit -= sum;
                    arrears += sum;
                    Console.WriteLine($"Acc : {GetId()}\tWithdraw {sum} successful, total balance : {Balance}\tCredit limit : {_limit}");
                }
                else Console.WriteLine($"Not enough to withdraw from balance\t Balance : {Balance}\tCredit limit : {_limit}");
            }
            else
            {
                Console.WriteLine($"Not enough to withdraw from balance\t Balance : {Balance}");
            }
        }
    }
}

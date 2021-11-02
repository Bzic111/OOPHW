using System;
using System.Globalization;

namespace OOPHomework
{
    class NightmareAccount : IAccount
    {
        private static int _counter { get; set; } = 0;
        private int _id { get; set; } = ++_counter;
        private decimal _balance { get; set; }
        private decimal _limit { get; set; } = 0;
        private decimal _arrears { get; set; } = 0;

        public AccountType AccType { get; private set; }
        public string Id { get => $"NMA_{_id.ToString("D8")}"; }
        public string Balance { get => _balance.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")); }
        public string Limit { get => _limit.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")); }
        public string Arrears { get => _arrears.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")); }

        public NightmareAccount() { }
        public NightmareAccount(decimal sum) : this() => _balance = sum;
        public NightmareAccount(AccountType accType, decimal limit = 0) : this((decimal)0)
        {
            AccType = accType;
            _limit = limit;
        }

        public void AccountInfo()
        {
            string answer = $"AccId\t:\t{Id}\nType\t:\t{AccType}\n";
            answer += $"Balance\t:\t{Balance}";
            if (AccType == AccountType.Credit) answer += $"\nLimit\t:\t{Limit}\nArrears\t:\t{Arrears}";
            Console.WriteLine(answer);
        }
        public void Enrollment(decimal sum)
        {
            string answer = null;
            string strSum = sum.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));
            if (_arrears > sum && _arrears > 0)
            {
                _arrears -= sum;
                _limit += sum;
                answer = $"Acc : {Id}\tEnroll {strSum} successful, arrears : {Arrears}\tLimit : {Limit}";
            }
            else if (_arrears == 0)
            {
                _balance += sum;
                answer = $"Acc : {Id}\tEnroll {strSum} successful, total balance : {Balance}";
            }
            else if (_arrears <= sum)
            {
                _limit += _arrears;
                _balance += sum - _arrears;
                _arrears = 0;
                answer = $"Acc : {Id}\tEnroll {strSum} successful, arrears : {Arrears}\tLimit : {Limit}\t Balance : {Balance}";
            }
            Console.WriteLine(answer);
        }
        public void Withdraw(decimal sum)
        {
            string answer;
            string strSum = sum.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));
            if (_balance >= sum)
            {
                _balance -= sum;
                answer = $"Acc : {Id}\tWithdraw {strSum} successful, total balance : {Balance}";
            }
            else if (_balance < sum && AccType == AccountType.Credit)
            {
                if (_balance + _limit >= sum)
                {
                    _limit -= sum - _balance;
                    _balance = 0;
                    _arrears += sum - _balance;
                    answer = $"Acc : {Id}\tWithdraw {strSum} successful, total balance : {Balance}\tCredit limit : {Limit}";
                }
                else answer = $"Not enough to withdraw from balance\t Balance : {Balance}\tCredit limit : {Limit}";
            }
            else answer = $"Not enough to withdraw from balance\t Balance : {Balance}";
            Console.WriteLine(answer);
        }
        public void Transfer(NightmareAccount from, decimal sum)
        {
            string answer;
            if (from._balance >= sum)
            {
                _balance += sum;
                from.Withdraw(sum);
                answer = $"Money transfered from {from.Id} :\n{Id}\tCurrent balance: {Balance}";
            }
            else if (from._balance <= sum && from.AccType == AccountType.Credit)
            {
                Enrollment(sum);
                from.Withdraw(sum);
                if (_balance == 0 && AccType == AccountType.Credit) answer = $"Money transfered from {from.Id} :\n{Id}\tCurrent balance: {Balance}\tLimit : {Limit}\tArrears : {Arrears}";
                else answer = $"Money transfered from {from.Id} :\n{Id}\tCurrent balance: {Balance}";
            }
            else answer = $"Not enough money to transfer.";
            Console.WriteLine(answer);
        }
        public void SetLimit(decimal sum) => _limit = sum;
        public AccountType GetAccType() => AccType;
        public decimal GetBalance() => _balance;
    }
}
//public void IncreaseLimit(decimal sum)
//{
//    if (AccType == AccountType.Credit) _limit += sum;
//    else Console.WriteLine($"Account type not support credit limit.");
//}
//public void DecreaseLimit(decimal sum)
//{
//    if (_limit >= sum) _limit -= sum;
//    else Console.WriteLine("Credit Limit to low");
//}

using System;
using System.Globalization;

namespace OOPHomework
{
    class HardAccount : IAccount
    {
        private static int counter = 0;
        private int _id;
        private AccountType _accType;
        private decimal _balance;
        private decimal _limit = 0;
        private decimal _arrears = 0;
        public string Balance { get => _balance.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")); }
        public string Limit { get => _limit.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")); }
        public string Arrears { get => _arrears.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")); }


        public HardAccount() => SetId();
        public HardAccount(decimal sum) : this() => _balance = sum;
        public HardAccount(AccountType accType) : this() => _accType = accType;
        public HardAccount(AccountType accType, decimal sum) : this()
        {
            _balance = sum;
            _accType = accType;
        }

        public void AccountInfo()
        {
            string answer = $"AccId\t:\t{GetId()}\nType\t:\t{_accType}\n";
            answer += $"Balance\t:\t{Balance}";
            if (_accType == AccountType.Credit) answer += $"\nLimit\t:\t{Limit}\nArrears\t:\t{Arrears}";
            Console.WriteLine(answer);
        }
        private void SetId()
        {
            counter++;
            _id = counter;
        }
        public string GetId() => $"HA_{_id.ToString("D8")}";
        public void Enrollment(decimal sum)
        {
            string answer = null;
            string strSum = sum.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));
            if (_arrears > sum && _arrears > 0)
            {
                _arrears -= sum;
                _limit += sum;
                answer = $"Acc : {GetId()}\tEnroll {strSum} successful, arrears : {Arrears}\tLimit : {Limit}";
            }
            else if (_arrears == 0)
            {
                _balance += sum;
                answer = $"Acc : {GetId()}\tEnroll {strSum} successful, total balance : {Balance}";
            }
            else if (_arrears <= sum)
            {
                _limit += _arrears;
                _balance += sum - _arrears;
                _arrears = 0;
                answer = $"Acc : {GetId()}\tEnroll {strSum} successful, arrears : {Arrears}\tLimit : {Limit}\t Balance : {Balance}";
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
                answer = $"Acc : {GetId()}\tWithdraw {strSum} successful, total balance : {Balance}";
            }
            else if (_balance < sum && _accType == AccountType.Credit)
            {
                if (_balance + _limit >= sum)
                {
                    _limit -= sum - _balance;
                    _balance = 0;
                    _arrears += sum - _balance;
                    answer = $"Acc : {GetId()}\tWithdraw {strSum} successful, total balance : {Balance}\tCredit limit : {Limit}";
                }
                else answer = $"Not enough to withdraw from balance\t Balance : {Balance}\tCredit limit : {Limit}";
            }
            else answer = $"Not enough to withdraw from balance\t Balance : {Balance}";
            Console.WriteLine(answer);
        }
        public decimal GetBalance() => _balance;
        public AccountType GetAccType() => _accType;
        public void SetLimit(decimal sum) => _limit = sum;
    }
}

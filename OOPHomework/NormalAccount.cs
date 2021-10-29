namespace OOPHomework
{
    class NormalAccount : LightAccount
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
        public new string GetId() => $"NA{_id.ToString("D8")}";
        //public void Enrollment(decimal sum) => _balance += sum;
        //public void Withdraw(decimal sum) => _balance -= sum;
        //public decimal GetBalance() => _balance;
        //public AccountType GetAccType() => _accType;
    }
}

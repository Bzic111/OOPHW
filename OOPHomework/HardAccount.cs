namespace OOPHomework
{
    class HardAccount : LightAccount
    {
        private static int counter = 0;
        private int _id;
        private decimal _balance;
        private AccountType _accType;

        public HardAccount() => SetId();
        public HardAccount(decimal sum) : this() => _balance = sum;
        public HardAccount(AccountType accType) : this() => _accType = accType;
        public HardAccount(AccountType accType, decimal sum) : this()
        {
            _balance = sum;
            _accType = accType;
        }

        private void SetId()
        {
            counter++;
            _id = counter;
        }
        public new string GetId() => $"HA{_id.ToString("D8")}";
        //public decimal GetBalance() => _balance;
        //public AccountType GetAccType() => _accType;
        //public void Enrollment(decimal sum) => _balance += sum;
        //public void Withdraw(decimal sum) => _balance -= sum;
    }
}

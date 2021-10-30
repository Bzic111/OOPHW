namespace OOPHomework
{
    public interface IAccount
    {
        string Arrears { get; }
        string Balance { get; }
        string Limit { get; }
        AccountType GetAccType();
        decimal GetBalance();
        void SetLimit(decimal sum);
        void AccountInfo();
        void Enrollment(decimal sum);
        void Withdraw(decimal sum);
    }
}
using OOPHomework.Enum;
using System.Text;

/// <summary>Расширенный банковский счёт</summary>
class NightmareAccount : IAccount, IEquatable<NightmareAccount>
{
    private static int _counter { get; set; } = 0;
    private static CultureInfo _culture = CultureInfo.CreateSpecificCulture("en-US");

    private int _id { get; init; } = ++_counter;
    private decimal _balance { get; set; }
    private decimal _limit { get; set; } = 0;
    private decimal _arrears { get; set; } = 0;
    private List<string> _operations { get; set; }

    public AccountType AccType { get; private set; }
    public string Id { get => $"NMA_{_id.ToString("D8")}"; }
    public string Balance { get => _balance.ToString("C2", _culture); }
    public string Limit { get => _limit.ToString("C2", _culture); }
    public string Arrears { get => _arrears.ToString("C2", _culture); }

    private NightmareAccount() { _operations = new List<string>(); }
    private NightmareAccount(decimal sum) : this() => _balance = sum;
    public NightmareAccount(AccountType accType, decimal limit = 0) : this((decimal)0)
    {
        _operations = new List<string>();
        AccType = accType;
        _limit = limit;
        _operations.Add($"Created new account ID: {Id}, Type: {AccType}");
    }

    public string AccountInfo()
    {
        string answer = $"AccId\t:\t{Id}\nType\t:\t{AccType}\n";
        answer += $"Balance\t:\t{Balance}";
        if (AccType == AccountType.Credit) answer += $"\nLimit\t:\t{Limit}\nArrears\t:\t{Arrears}";
        return answer;
    }
    public void Enrollment(decimal sum)
    {
        string strSum = sum.ToString("C2", _culture);
        string answer = $"Acc : {Id}\tEnroll {strSum} is failed";
        if (_arrears > sum && _arrears > 0)
        {
            _arrears -= sum;
            _limit += sum;
            answer = $"Enrollment result: Acc : {Id}\tEnroll {strSum} successful, arrears : {Arrears}\tLimit : {Limit}";
        }
        else if (_arrears == 0)
        {
            _balance += sum;
            answer = $"Enrollment result: Acc : {Id}\tEnroll {strSum} successful, total balance : {Balance}";
        }
        else if (_arrears <= sum)
        {
            _limit += _arrears;
            _balance += sum - _arrears;
            _arrears = 0;
            answer = $"Enrollment result: Acc : {Id}\tEnroll {strSum} successful, arrears : {Arrears}\tLimit : {Limit}\t Balance : {Balance}";
        }
        _operations.Add(answer);
    }
    public void Withdraw(decimal sum)
    {
        string answer;
        string strSum = sum.ToString("C2", _culture);
        if (_balance >= sum)
        {
            _balance -= sum;
            answer = $"Withdraw result: Acc : {Id}\tWithdraw {strSum} successful, total balance : {Balance}";
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
        else answer = $"Withdraw result: Not enough to withdraw from balance\t Balance : {Balance}";
        _operations.Add(answer);
    }
    /// <summary>Перевод средств со счёта на счёт</summary>
    /// <param name="from">Источник</param>
    /// <param name="sum">сумма</param>
    public void Transfer(NightmareAccount from, decimal sum)
    {
        if (!Equals(from))
        {
            string answer;
            if (from._balance >= sum)
            {
                _balance += sum;
                from.Withdraw(sum);
                answer = $"Transfer result: Money transfered from {from.Id} :\n{Id}\tCurrent balance: {Balance}";
            }
            else if (from._balance <= sum && from.AccType == AccountType.Credit)
            {
                Enrollment(sum);
                from.Withdraw(sum);
                if (_balance == 0 && AccType == AccountType.Credit) answer = $"Money transfered from {from.Id} :\n{Id}\tCurrent balance: {Balance}\tLimit : {Limit}\tArrears : {Arrears}";
                else answer = $"Money transfered from {from.Id} :\n{Id}\tCurrent balance: {Balance}";
            }
            else answer = $"Transfer result: Not enough money to transfer.";
            _operations.Add(answer);
        }
    }
    public void SetLimit(decimal sum) => _limit = sum;
    public AccountType GetAccType() => AccType;
    public decimal GetBalance() => _balance;
    public string GetLastOperation() => _operations != null && _operations.Count != 0 ? _operations[_operations.Count - 1] : "Nothing to show";
    public string GetOperations(int start, int end)
    {
        if (_operations != null && _operations.Count != 0)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = start; i < _operations.Count || i < end; i++)
            {
                sb.Append(_operations[i] + '\n');
                if (_operations.Count < end && i == _operations.Count - 1)
                    sb.Append("End of list");
            }
            return sb.ToString();
        }
        return "Nothing to show";
    }
    public string GetAllOperations()
    {
        if (_operations != null && _operations.Count != 0)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in _operations)
                sb.Append(item + "\n");
            return sb.ToString();
        }
        else return "Nothing to show";
    }
    public string GetOperations(string operation)
    {
        if (_operations != null && _operations.Count != 0)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in _operations)
                if (item.Contains(operation))
                    sb.Append(item + "\n");
            return sb.ToString();
        }
        return "Nothing to show";
    }
    public static bool operator ==(NightmareAccount? a, NightmareAccount? b)
    {
        if (a.Equals(null) && b.Equals(null)) return false;
        else if (ReferenceEquals(a, b)) return true;
        else return a._balance == b._balance &&
                    a.AccType == b.AccType &&
                    a._limit == b._limit &&
                    a._arrears == b._arrears;
    }
    public static bool operator !=(NightmareAccount a, NightmareAccount b) => !(a == b);
    bool IEquatable<NightmareAccount>.Equals(NightmareAccount? other) => this == other;
    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) && !(ReferenceEquals(obj, null)) &&
            obj.GetType() == this.GetType() ? this == (NightmareAccount)obj : false;
    }
    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = _id.GetHashCode();
            hashCode = (hashCode * 317) ^ (int)_balance;
            hashCode = (hashCode * 317) | (int)_limit;
            hashCode = (hashCode * 317) & ~(int)_arrears;
            return hashCode;
        }
    }
    public override string ToString() => AccountInfo();
}
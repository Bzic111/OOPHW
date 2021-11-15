using OOPHomework.Enum;
namespace OOPHomework;
/// <summary>Банковский счёт</summary>
public interface IAccount
{
    /// <summary>Задолженность</summary>
    string Arrears { get; }
    /// <summary>Баланс</summary>
    string Balance { get; }
    /// <summary>Кредитный лимит</summary>
    string Limit { get; }
    /// <returns>Тип счёта</returns>
    AccountType GetAccType();
    /// <summary>Остаток на балансе</summary>
    decimal GetBalance();
    /// <summary>Установить кредитный лимит</summary>
    /// <param name="sum">Сумма</param>
    void SetLimit(decimal sum);
    /// <summary>Реквизиты</summary>
    string AccountInfo();
    /// <summary>Внести средства на счёт</summary>
    /// <param name="sum">Сумма</param>
    void Enrollment(decimal sum);
    /// <summary>Снять средства со счёта</summary>
    /// <param name="sum"></param>
    void Withdraw(decimal sum);
}

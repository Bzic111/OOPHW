global using System;
global using System.Globalization;
global using System.Collections.Generic;

NightmareAccount na1 = new NightmareAccount(AccountType.Debit);
NightmareAccount na2 = new NightmareAccount(AccountType.Debit);
NightmareAccount na3 = new NightmareAccount(AccountType.Debit);
NightmareAccount na4 = new NightmareAccount(AccountType.Debit);

List<IAccount> lna = new List<IAccount> { na1, na2, na3, na4 };
foreach (var item in lna)
{
    item.Enrollment(10000);
    Console.WriteLine(item);
    Console.WriteLine(item.GetHashCode());
}
if (na1==na2) na1.Transfer(na2, 1000);
Console.WriteLine(na1.GetAllOperations());
Console.WriteLine(na2.GetAllOperations());
Console.WriteLine(na3.GetAllOperations());
Console.WriteLine(na4.GetAllOperations());
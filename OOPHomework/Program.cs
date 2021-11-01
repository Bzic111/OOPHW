using System;
using System.Text;
using System.IO;

namespace OOPHomework
{
    public enum AccountType
    {
        Debit,
        Credit
    }

    class Program
    {
        static void Main(string[] args)
        {
            MailFinding.Run();
            Console.WriteLine("Читаем строки из сгенерированного файла\n");
            MailFinding.FileToConsole("test.txt", 5, 8);
            Console.WriteLine("\nЧитаем строки из итогового файла\n");
            MailFinding.FileToConsole("testOutput.txt", 5, 8);

            Console.WriteLine("\n Запуска теста для бановских счетов");

            BankAccountClasses.Run();
        }

        /// <summary>
        /// Методд раззворота строки.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static string Reverse(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--) sb.Append(str[i]);
            return sb.ToString();
        }
    }
}

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
            MailFinding.FileToConsole("test.txt", 5, 8);
            MailFinding.FileToConsole("testOutput.txt", 5, 8);
        }
        static string Reverse(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = str.Length-1; i >= 0; i--) sb.Append(str[i]);
            return sb.ToString();
        }
        static void FindMail(ref string str)
        {
            Span<char> charSpan = new Span<char>(str.ToCharArray());

        }
    }
}

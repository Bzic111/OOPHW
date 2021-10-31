using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;


namespace OOPHomework
{
    static class MailFinding
    {
        public static void Run()
        {
            GenerateLine(25);
            using (StreamReader sr = new StreamReader("test.txt"))
            {
                string temp;
                FileInfo fi = new("testOutput.txt"); if (fi.Exists) fi.Delete();
                while (!sr.EndOfStream)
                {
                    string s = sr.Read( )
                    temp = sr.ReadLine().Split('&')[1].Trim();
                    if (Regex.IsMatch(temp, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    {
                        using(StreamWriter sw = new StreamWriter("testOutput.txt", true))
                        {
                            sw.WriteLine(temp);
                        }
                    }
                }
            }
        }
        public void SearchMail(ref string s)
        {

        }
        public static void FileToConsole(string fileName, int start = 0, int end = 0)
        {
            using(StreamReader sr = new StreamReader(fileName))
            {
                for (int i = 0; i <= end && !sr.EndOfStream ; i++)
                {
                    if (i >= start) Console.WriteLine(sr.ReadLine());
                    else sr.ReadLine();
                }
            }
        }
        static void GenerateLine(int lines)
        {
            using (StreamWriter sw = new StreamWriter("test.txt", false))
            {
                for (int i = 0; i < lines; i++)
                {
                    sw.WriteLine($"{WordGenerator(5)} {WordGenerator(7)} {WordGenerator(8)} & {GenerateMail(9)}");
                }
            }
        }
        static string WordGenerator(int lenght)
        {
            Random rnd = new();
            char[] chr = new char[lenght];
            for (int i = 0; i < lenght; i++)
            {
                rnd.Next(rnd.Next(rnd.Next()));
                chr[i] = Convert.ToChar(rnd.Next('a', 'z'));
            }

            return new(chr);
        }
        static string GenerateMail(int lenght) => $"{WordGenerator(lenght)}@{WordGenerator(6)}.{WordGenerator(3)}";
    }
}

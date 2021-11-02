using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;


namespace OOPHomework
{
    class MailFinding
    {
        /// <summary>
        /// Формирование файла с адресами эл.почты. Файл читается посимвольно до '&',
        /// далее передаёт готовую строку в метод SearchMail(ref string)
        /// если строка содержит искомый паттерн, то остаётся только подходящее слово,
        /// иначе строка становится null
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("Запуск генерации исходного файла");
            GenerateLine(25);
            using (StreamReader sr = new StreamReader("test.txt"))
            {
                string temp;
                char chr;
                StringBuilder sb = new StringBuilder();
                FileInfo fi = new("testOutput.txt"); if (fi.Exists) fi.Delete();
                while (!sr.EndOfStream)
                {
                    sb.Clear();
                    do
                    {
                        chr = (char)sr.Read();
                        if (chr != '\r' && chr != '\n') sb.Append(chr);
                    } while ((chr != '&') && (chr != '\n'));
                    temp = sb.ToString();
                    SearchMail(ref temp);
                    if (temp != null)
                        using (StreamWriter sw = new StreamWriter("testOutput.txt", true))
                            sw.WriteLine(temp);
                }
            }
        }

        /// <summary>
        /// Метод поиска по паттерну эл.почты.
        /// </summary>
        /// <param name="s">строка для поискаа</param>
        static void SearchMail(ref string s)
        {
            string[] temp = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in temp)
                if (Regex.IsMatch(item, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) s = item;
                else s = null;
        }

        /// <summary>
        /// Вывод определённых строк файла в консоль
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="start">начальная строка</param>
        /// <param name="end">конечная строка</param>
        public static void FileToConsole(string fileName, int start = 0, int end = 0)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                for (int i = 0; i <= end && !sr.EndOfStream; i++)
                    if (i >= start) Console.WriteLine(sr.ReadLine());
                    else sr.ReadLine();
            }
        }

        /// <summary>
        /// Генерация строки для файла.
        /// </summary>
        /// <param name="lines">количество линий</param>
        static void GenerateLine(int lines)
        {
            using (StreamWriter sw = new StreamWriter("test.txt", false))
            {
                Random rnd = new Random(); rnd.Next(rnd.Next(rnd.Next()));
                for (int i = 0; i < lines; i++)
                    sw.WriteLine($"{WordGenerator(rnd.Next(5, 10))} {WordGenerator(rnd.Next(5, 10))} {WordGenerator(rnd.Next(5, 10))} & {GenerateMail(rnd.Next(5, 10))}");
            }
        }

        /// <summary>
        /// Генератор слова.
        /// </summary>
        /// <param name="lenght"></param>
        /// <returns>набор символов определённой длины</returns>
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

        /// <summary>
        /// Генератор слова, похожего на адрес электронной почты
        /// </summary>
        /// <param name="lenght">длинна имени</param>
        /// <returns>набор символов подходящий под паттерн ^[^@\s]+@[^@\s]+\.[^@\s]+$</returns>
        static string GenerateMail(int lenght) => $"{WordGenerator(lenght)}@{WordGenerator(6)}.{WordGenerator(3)}";
    }
}

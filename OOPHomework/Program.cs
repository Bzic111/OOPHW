using System;

namespace OOPHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational r1 = new(5, 6);
            Rational r2 = (5, 7);
            
            string s1 = r1 + r2;
            decimal dec = r1 / r2;
            float f1 = r1 + r2;
            double d = r1 + f1 + dec;
            Rational r3 = s1 + r1 + r2 + f1 + d + dec;
            Rational r4 = (Rational)5 + (2, 5);
            int i1 = -r3;
            (int,int) v = r1;
            Console.WriteLine(r4.ToString());
            Console.WriteLine(v);
            Console.WriteLine(i1);
            Console.WriteLine((string)r3);
            Console.WriteLine(s1);
            Console.WriteLine($"{r1}") ;
            Console.WriteLine(r2.ToString());
            Console.WriteLine($"{r1} + {r2} = {r1 + r2}");
            Console.WriteLine($"{r1} - {r2} = {r1 - r2}");
            Console.WriteLine($"{r1} * {r2} = {r1 * r2}");
            Console.WriteLine($"{r1} / {r2} = {r1 / r2}");
            Console.WriteLine($"{r1} == {r2} is {r1 == r2}");
            Console.WriteLine($"{r1} != {r2} is {r1 != r2}");
            Console.WriteLine($"{r1} > {r2} is {r1 > r2}");
            Console.WriteLine($"{r1} < {r2} is {r1 < r2}");
            Console.WriteLine($"{r1} + (float){1.5f} = {r1 + 1.5f}");
            Console.WriteLine($"{r2} * (string)\"2/5\" = {r2 * "2/5"}");
            Console.WriteLine($"{r1} * {r2} ToDecimal = {(decimal)(r1 * r2)}");
        }
    }
}
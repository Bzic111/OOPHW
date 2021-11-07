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
            int i1 = -r3;
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
    /// <summary>Рациональное число</summary>
    public readonly struct Rational : IEquatable<Rational>
    {
        /// <summary>Числитель</summary>
        public int M { get; init; }
        /// <summary>Знаменатель</summary>
        public int N { get; init; }
        /// <summary>Рациональное число</summary>
        /// <param name="m">Числитель</param>
        public Rational(int m) : this(m, 1) { }
        public Rational(int m, int n)
        {
            if (m == 0) M = N = m;
            else if (n == 0) throw new DivideByZeroException();
            else
            {
                M = m; N = n;
            }
        }
        /// <summary>Упрощение дроби</summary>
        /// <returns>Дробь</returns>
        public Rational Reduction()
        {
            for (int i = N; i > 1; i--)
                if (M % i == 0 && N % i == 0)
                    return new(M / i, N / i);
            return this;
        }
        
        /// <summary>Приведение строки к рациональному числу</summary>
        /// <param name="str">строка</param><param name="separator">Разделитель, по умолчанию '/'</param>
        /// <returns>Если строка не содержит рационального числа, то вернёт рациональное число вида 0/0</returns>
        public static Rational ToRational(string str, char separator = '/')
        {
            int m, n = m = 0;
            string[] temp = str.Trim().Split(separator);
            if (temp.Length == 2)
            {
                int.TryParse(temp[0], out m);
                int.TryParse(temp[1], out n);
                if (n == 0) n = 1;
            }
            else if (temp.Length == 1)
            {
                int.TryParse(temp[0], out m);
                n = 1;
            }
            else
            {
                return null;
            }
            return new Rational(m, n);
        }
        
        /// <summary>Очень удобный способ создания объекта рационального числа</summary>
        /// <remarks>Например: <code><typeparamref name="Rational"/> r = (5, 7);</code></remarks>
        /// <param name="v">Кортеж (int, int)</param>
        public static implicit operator Rational((int, int) v) => new(v.Item1, v.Item2);
        
        /// <summary>Создаёт новый объект рационального числа</summary>
        /// <remarks>Создаёт дробь в которой числитель равен <paramref name="a"/> и знаменатель равен 1</remarks>
        /// <param name="a">Целое</param>
        public static implicit operator Rational(int a) => new(a);
        
        /// <summary>Создаёт новый объект из десятичной дроби</summary>
        public static implicit operator Rational(double a) => (float)a;
        
        /// <summary>Создаёт новый объект из десятичной дроби</summary>
        public static implicit operator Rational(decimal a) => (float)a;
        
        /// <summary>Создаёт новый объект из десятичной дроби</summary>
        public static implicit operator Rational(float a)
        {
            int iter = 1;
            while (Math.Truncate(a) / a != 1)
            {
                a *= 10;
                iter *= 10;
            }
            return new((int)a, iter);
        }
        
        /// <summary>Неявное приведение строки к рациональному числу, используется разделитель по умолчанию '/'</summary>
        public static implicit operator Rational(string s) => ToRational(s);
        
        // Дабы не расписывать математические операторы для каждого типа чисел, решил сделать неявное приведение типов
        // методы Console.WriteLine(); и Console.Write(); выдают ошибку, так как пытаются привести дробь к чему-то знакомому
        // решить эту проблему я пока не смог, возможно в будущем найду ответ.


        /// <summary>Строковое представление рационального числа</summary>
        public static /*explicit*/ implicit operator string(Rational a) => a.ToString();
        /// <summary>Приведение дроби к целому</summary><returns>Целую часть дроби</returns>
        public static /*explicit*/ implicit operator int(Rational a) => a.M == 0 | a.N == 0 ? 0 : a.M / a.N;
        /// <summary>Приведение рационального числа к десятичной дроби</summary>
        public static /*explicit*/ implicit operator decimal(Rational a) => (decimal)(float)a;
        /// <summary>Приведение рационального числа к десятичной дроби</summary>
        public static /*explicit*/ implicit operator double(Rational a) => (float)a;
        /// <summary>Приведение рационального числа к десятичной дроби</summary>
        public static /*explicit*/ implicit operator float(Rational a)
        {
            if (a.M == 0) return 0;
            else return a.M * (1f / a.N);
        }

        /// <summary>Возвращает результат сравнения двух <typeparamref name="Rational"/> чисел</summary>
        /// <returns><typeparamref name="bool"/> <paramref name="true"/> если равны и <paramref name="false"/> если нет</returns>
        public static bool operator ==(Rational a, Rational b)
        {
            if (a.N == b.N) return a.M == b.M;
            else return a.M * b.N == b.M * a.N;
        }
        /// <summary>Возвращает результат сравнения двух <typeparamref name="Rational"/> чисел</summary>
        /// <returns><typeparamref name="bool"/> <paramref name="true"/> если не равны и <paramref name="false"/> если равны</returns>
        public static bool operator !=(Rational a, Rational b) => !(a == b);
        /// <summary>Возвращает результат сравнения двух <typeparamref name="Rational"/> чисел</summary>
        /// <returns><typeparamref name="bool"/> <paramref name="true"/> если <paramref name="a"/> больше чем <paramref name="b"/>
        /// иначе <paramref name="false"/></returns>
        public static bool operator >(Rational a, Rational b)
        {
            if (a.M == 0) return 0 > b.M;
            else if (b.M == 0) return a.M > 0;
            else if (a.N == b.N) return a.M > b.M;
            else return a.M * b.N > b.M * a.N;
        }
        /// <summary>Возвращает результат сравнения двух <typeparamref name="Rational"/> чисел</summary>
        /// <returns><typeparamref name="bool"/> <paramref name="true"/> если <paramref name="a"/> меньше чем <paramref name="b"/>
        /// иначе <paramref name="false"/></returns>
        public static bool operator <(Rational a, Rational b)
        {
            if (a.M == 0) return 0 < b.M;
            else if (b.M == 0) return a.M < 0;
            else if (a.N == b.N) return a.M < b.M;
            else return a.M * b.N < b.M * a.N;
        }
        /// <summary>Возвращает результат сравнения двух <typeparamref name="Rational"/> чисел</summary>
        /// <returns><typeparamref name="bool"/> <paramref name="true"/> если <paramref name="a"/> меньше или равен <paramref name="b"/>
        /// иначе <paramref name="false"/></returns>
        public static bool operator <=(Rational a, Rational b)
        {
            if (a.N == b.N) return a.M <= b.M;
            else return a.M * b.N <= b.M * a.N;
        }
        /// <summary>Возвращает результат сравнения двух <typeparamref name="Rational"/> чисел</summary>
        /// <returns><typeparamref name="bool"/> <paramref name="true"/> если <paramref name="a"/> больше или равен <paramref name="b"/>
        /// иначе <paramref name="false"/></returns>
        public static bool operator >=(Rational a, Rational b)
        {
            if (a.N == b.N) return a.M >= b.M;
            else return a.M * b.N >= b.M * a.N;
        }

        /// <summary>Сложение дробей</summary>
        public static Rational operator +(Rational a, Rational b)
        {
            if (a.N == b.N) return new(a.M + b.M, a.N);
            else if (a.M == 0) return b;
            else if (b.M == 0) return a;
            else return new(a.M * b.N + b.M * a.N, a.N * b.N);
        }
        /// <summary>Разность дробей</summary>
        public static Rational operator -(Rational a, Rational b)
        {
            if (a.N == b.N) return new(a.M - b.M, a.N);
            else if (a.M == 0) return new(-(b.N - b.M), b.N);
            else if (b.M == 0) return new(-(a.N - a.M), a.N);
            else return new(a.M * b.N - b.M * a.N, a.N * b.N);
        }
        /// <summary>смена знака дроби</summary>
        public static Rational operator -(Rational a)
        {
            return a * (-1);
        }
        /// <summary>Умножение дробей</summary>
        public static Rational operator *(Rational a, Rational b) => new(a.M * b.M, a.N * b.N);
        /// <summary>Деление дробей</summary>
        public static Rational operator /(Rational a, Rational b) => new(a.M * b.N, a.N * b.M);
        /// <summary>Вычисление остатка от деления дробей</summary>
        /// <returns>Ужас всей математики</returns>
        public static Rational operator %(Rational a, Rational b)
        {
            if (a > 0) while (a >= b) a -= b;
            else if (a < 0) return -(-a % b);
            return a;
        }
        public override string ToString() => N == 1 ? $"{M}" : M == 0 ? "0" : $"{M}/{N}";
        public override bool Equals(object obj) => obj is Rational rational && Equals(rational);
        public bool Equals(Rational other) => M == other.M && N == other.N;
        public override int GetHashCode() => HashCode.Combine(M, N);
    }
}
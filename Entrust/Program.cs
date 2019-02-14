using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Entrust
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Func<int, int> fac = null;
            //fac = x => x <= 1 ? 1 : x * fac(x - 1);
            //Console.WriteLine(fac(5)); // 120;

            //Func<int, int> facAlias = fac;
            //fac = x => x;
            //Console.WriteLine(facAlias(5)); // 20



            //int[] ints1 = fun1.GetSequence(10).ToArray();
            //int[] ints2 = fun2.GetSequence(10).ToArray();
            //int[] ints3 = fun3.GetSequence(10).ToArray();


            //int[] ints4 = Fibonacci.GetSequence(10).ToArray();
            //int[] ints5 = fac.GetSequence(10).ToArray();

            //int[] ints6 = Power(1, 8).ToArray();

            //委托扩展方法 + 递推递归委托
            int[] fibonacciSequence = Fibonacci.GetSequence(12).ToArray();



            //int aaa = 1;
            //int bbb = 2;
            //int ccc = 0;
            //if (aaa == (1 | 2 | 3) && bbb == (1 | 2 | 3))
            //{
            //    if (aaa == bbb)
            //    {
            //        Console.WriteLine(ccc);
            //    }
            //    else if (aaa + bbb >= 3)
            //    {
            //        Console.WriteLine(3);
            //    }
            //}

            Console.ReadLine();
        }

        //Fibonacci数组
        public static readonly Func<int, int> Fibonacci = n => n > 1 ? Fibonacci(n - 1) + Fibonacci(n - 2) : n;
        //阶乘
        public static readonly Func<int, int> fac = x => x <= 1 ? 1 : x * fac(x - 1);



        //数列1 通项公式
        public static Func<int, int> fun1 = n => 1;
        //数列2 通项公式
        public static Func<int, int> fun2 = n => n;
        //数列3 通项公式
        public static Func<int, int> fun3 = n => n * n;


        public static Func<int, int> Fibonacci2 = n => (int)(5.0.Pow(-0.5) * ((0.5 * (1 + 5.0.Pow(0.5))).Pow(n + 1) - (0.5 * (1 - 5.0.Pow(0.5))).Pow(n + 1)));
        //Pow扩展，简化调用
        public static double Pow(this double x, double y)
        {
            return Math.Pow(x, y);
        }




        /**//// <summary>
        /// 生成队列的前count项
        /// </summary>
        /// <param name="func">通项公式</param>
        /// <param name="count">生成的数量</param>
        /// <returns>队列前count项</returns>
        public static IEnumerable<int> GetSequence(this Func<int, int> func, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return func(i);
            }
        }

        public static int GetFibonacci(int n)
        {
            if (n > 1)
                return GetFibonacci(n - 1) + GetFibonacci(n - 2);
            else
                return n;
        }


        public static IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;
            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
            }
            yield return 3;
            yield return 4;
        }
    }
}

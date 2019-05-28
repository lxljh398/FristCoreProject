using System;

namespace DelegateAndEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            //var oAction1 = new Action(Test1);
            //oAction1.Invoke();
            //oAction1();

            ////2.有参无返回值
            //var oAction2 = new Action<int, int, int>(Test5);
            //oAction2.Invoke(1, 2, 3);
            //oAction2(1, 2, 3);

            //var oFun1 = new Func<object>(Test3);
            //var ofuncRes1 = oFun1.Invoke();

            //var oFunc2 = new Func<string, object>(Test4);
            //oFunc2("a");

            //var oFunc3 = new Func<int, int, int, int>(Test6);
            //Console.WriteLine(oFunc3(1, 5, 8));


            //Func<string> func = delegate
            //{
            //    Console.WriteLine("aaaaaaaaaaaaaaaaa");
            //    return "aaa";
            //};
            //Disp(func);

            //Func<string> func1 = () => { return "aa"; };
            //Func<string> func2 = () => "aaa";
            //Disp(func2);

            //Action<string> action = (p => Console.WriteLine("方法1" + p));
            Action<int, int, int> action1 = ((p1, p2, p3) => Console.WriteLine(p1 + p2 + p3));
            action1(1, 5, 8);

            Func<int, int, int, int> func = ((p1, p2, p3) => p1 + p2 + p3);
            int aa = func(1, 5, 8);

            Console.ReadLine();
        }

        private static void Disp(Func<string> func)
        {
            string aaa = func();
            Console.WriteLine("我在测试一下传过来值：{0}", aaa);
        }


        private static void Test5(int a, int b, int c)
        {
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }

        private static int Test6(int a, int b, int c)
        {
            return a + b + c;
        }


        //无参数无返回值
        private static void Test1()
        {
            Console.WriteLine("Func Test1, No Parameter");
        }

        //有参数无返回值
        private static void Test2(string str)
        {
            Console.WriteLine("Func Test2, Parameter is" + str);
        }

        //无参数有返回值
        private static object Test3()
        {
            Console.WriteLine("Func Test3, Parameter");
            return Guid.NewGuid().ToString();
        }

        //有参数有返回值
        private static object Test4(string strRes)
        {
            Console.WriteLine("Func Test4,  Parameter and Return Value");
            return strRes;
        }



    }
}

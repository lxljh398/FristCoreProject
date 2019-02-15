using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Extend
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<User> listUser = new List<User>()
            // {
            //     new User() { Name = "张三", Password = "1234", Age = 12, DeptId = "0001" },
            //     new User() { Name = "张四", Password = "1234", Age = 16, DeptId = "0002" },
            //     new User() { Name = "张五", Password = "1234", Age = 29, DeptId = "0003" },
            //     new User() { Name = "张六", Password = "1234", Age = 18, DeptId = "0001" },
            //     new User() { Name = "张七", Password = "1234", Age = 12, DeptId = "0001" }
            // };

            //List<Dept> listDept = new List<Dept>()
            // {
            //     new Dept() { DeptId = "0001", DeptName = "人事部", PepNum = 10 },
            //     new Dept() { DeptId = "0002", DeptName = "财务部", PepNum = 7 },
            //     new Dept() { DeptId = "0003", DeptName = "行政部", PepNum = 15 }
            // };

            //listUser.TEach(PrintUser);
            //listUser.ForEach(delegate (User u) { Console.WriteLine(u.Name + " " + u.Password + " " + u.Age); });
            //listUser.ForEach(u => Console.WriteLine(u.Name + " " + u.Password + " " + u.Age));
            //listUser.ForEach(new Action<User>(delegate (User u) { Console.WriteLine(u.Name + " " + u.Password + " " + u.Age); }));


            //string str = "czx@123.com";
            //Console.WriteLine(str.isEmail());

            //Func<double, double, double> func = addtion;
            //double result = func(20, 30);
            //Console.WriteLine("Func带返回参数委托做加法结果为：{0}", func(10, 20));

            //Action<double, double> DoSubstraction = substraction;
            //DoSubstraction(90, 20);
            //Console.ReadLine();


            for (int a = 0; a <= 9; a++)
            {
                for (int b = 0; b <= 9; b++)
                {
                    if ((120569 + a * 1000) * 123 == 15404987 + b * 10000)
                    {
                        Console.WriteLine(a);
                        Console.WriteLine(b);
                    }
                }
            }
            Console.ReadLine();
        }


        /// <summary>
        /// 打印一个用户信息
        /// </summary>
        /// <param name="u"></param>
        public static void PrintUser(User u)
        {
            Console.WriteLine(u.Name + " " + u.Password + " " + u.Age);
        }

        /// <summary>
        /// 打印一个部门信息
        /// </summary>
        /// <param name="d"></param>
        public static void PrintDept(Dept d)
        {
            Console.WriteLine(d.DeptId + " " + d.DeptName + " " + d.PepNum);
        }

        public static double addtion(double x, double y)
        {
            return x + y;
        }
        public static void substraction(double x, double y)
        {
            Console.WriteLine("Action不带返回参数委托做减法结果为:{0}", x - y);
        }
    }


    /// <summary>
    /// List扩展方法
    /// </summary>
    public static class ListExtend
    {
        //声明自定义泛型委托
        public delegate void PrintT<T>(T t);

        public static void TEach<T>(this List<T> list, PrintT<T> pt)
        {
            foreach (T t in list)
            {
                pt(t);
            }
        }

        //扩展方法必须为静态的
        //扩展方法的第一个参数必须由this来修饰（第一个参数是被扩展的对象）
        public static bool isEmail(this string _string)
        {
            return Regex.IsMatch(_string,
                @"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$");
        }
    }

    public class Dept
    {
        public string DeptId { get; set; }
        public string DeptName { get; set; }
        public int PepNum { get; set; }
        public Dept()
        {

        }
    }
    public class User
    {
        /// <summary>
        /// 自动属性
        /// </summary>
        public string Name { get; set; }

        public string LoginName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public string Password { get; set; }
        public string DeptId { get; set; }

        //构造函数重载
        public User()
        {

        }
        public User(string name)
        {
            this.Name = name;
        }

        public User(string name, string loginName)
        {
            this.Name = name;
            this.LoginName = loginName;
        }

        /// <summary>
        /// 默认参数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="loginName"></param>
        /// <param name="age"></param>
        /// <param name="address"></param>
        /// <param name="password"></param>
        public User(string name, string loginName, int age, string address = "上海", string password = "1234")
        {
            this.Name = name;
            this.LoginName = loginName;
            this.Age = age;
            this.Address = address;
            this.Password = password;
        }
    }
}

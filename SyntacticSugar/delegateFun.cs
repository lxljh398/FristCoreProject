using System;
using System.Collections.Generic;

namespace SyntacticSugar
{
    class delegateFun
    {
        delegate void Printer(string s);
        public delegate void PrintEmployee(User u);

        static void Main(string[] args)
        {
            //User user = new User("lixin");
            //Console.WriteLine($"{ user.Name},{user.Age}");
            //User user1 = new User("lixin", "zzzz", password: "cccc");
            //Console.WriteLine($"{ user1.Name},{user1.Age},{user1.PWD}");



            //var newPeople = new { pName="lixin",pAge=20,pAddress="hz"};
            //Console.WriteLine("{0} is {1} years old", newPeople.pName, newPeople.pAge);






            //Printer p = delegate (string a)
            //{
            //    Console.WriteLine(a);
            //};
            //p("委托");



            //List<User> listUser = new List<User>()
            // {
            //     new User() { Name = "张三", Password = "1234", Age = 12, DeptId = "0001" },
            //     new User() { Name = "张四", Password = "1234", Age = 16, DeptId = "0002" },
            //     new User() { Name = "张五", Password = "1234", Age = 29, DeptId = "0003" },
            //     new User() { Name = "张六", Password = "1234", Age = 18, DeptId = "0001" },
            //     new User() { Name = "张七", Password = "1234", Age = 12, DeptId = "0001" }
            // };

            //ChangeUserPwd(listUser, delegate (User u)
            //     {
            //         Console.WriteLine(u.Name + "的新密码是:" + u.Password);
            //     });

            //ChangeUserPwd(listUser, u => {
            //    Console.WriteLine(u.Name + "的新密码是:" + u.Password);
            //});

            A a = new A();
            AB aB = new AB(a);
            AC aC = new AC(a);
            //a.Raise("左");
            a.Fall();
            Console.ReadLine();
        }

        //举杯
        public delegate void RaiseEventHandler(string hand);
        //摔杯
        public delegate void FallEventHandler();
        public class A
        {
            public event RaiseEventHandler RaiseEvent;
            public event FallEventHandler FallEvent;

            public void Raise(string hand)
            {
                Console.WriteLine("首领A{0}手举杯", hand);
                RaiseEvent(hand);
            }

            public void Fall()
            {
                Console.WriteLine("首领A摔杯");
                FallEvent();
            }
        }

        public class AB
        {
            A a;
            public AB(A a)
            {
                this.a = a;
                a.RaiseEvent += new RaiseEventHandler(A_RaiseEvent);
                a.FallEvent += new FallEventHandler(A_FallEvent);
            }

            private void A_FallEvent()
            {
                Attack();
            }

            private void A_RaiseEvent(string hand)
            {
                if (hand.Equals("左"))
                {
                    Attack();
                }
            }

            public void Attack()
            {
                Console.WriteLine("部下B发起攻击，大喊：猛人张飞来也！");
            }
        }

        public class AC
        {
            A a;
            public AC(A a)
            {
                this.a = a;
                a.RaiseEvent += new RaiseEventHandler(A_RaiseEvent);
                a.FallEvent += new FallEventHandler(A_FallEvent);
            }

            private void A_FallEvent()
            {
                Attack();
            }

            private void A_RaiseEvent(string hand)
            {
                if (hand == "右")
                {
                    Attack();
                }
            }

            public void Attack()
            {
                Console.WriteLine("部下C发起攻击，一套落英神掌打得虎虎生威~");
            }
        }



        public static void ChangeUserPwd(List<User> list, PrintEmployee callback)
        {
            int i = 0;
            foreach (User u in list)
            {
                u.Password = u.Password + i.ToString();
                i += 2;
                callback(u);
            }
        }

        private void Test()
        {
            Console.WriteLine();
        }


        internal class OneClass
        {

        }


        public class User
        {
            public string Name { get; set; }
            public string LoginName { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
            public string Password { get; set; }
            public string DeptId { get; set; }

            public User()
            {

            }
            public User(string Name)
            {
                this.Name = Name;
            }

            public User(string name, string loginName, int age = 0, string address = "上海", string password = "1234")
            {
                this.Name = name;
                this.LoginName = loginName;
                this.Age = age;
                this.Address = address;
                this.Password = password;
            }
        }
    }
}

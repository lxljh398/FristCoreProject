using System;
using System.Collections.Generic;
using System.Text;

namespace CastleWindsor
{
    public class Fun
    {
        //public class BeijingHello : IHello
        //{
        //    public void SayHello(string name)
        //    {
        //        Console.WriteLine($"{name}欢迎来北京");
        //    }
        //}
        //public class HangzhouHello : IHello
        //{
        //    public void SayHello(string name)
        //    {
        //        Console.WriteLine($"{name}欢迎来杭州");
        //    }
        //}
        //public class SHHello : IHello
        //{
        //    public void SayHello(string name)
        //    {
        //        Console.WriteLine($"{name}欢迎来上海");
        //    }
        //}


        public class BeijingHello : IBJHello
        {
            public void SayHello(string name)
            {
                Console.WriteLine($"{name}欢迎来北京");
            }
        }
        public class HangzhouHello : IHZHello
        {
            public void SayHello(string name)
            {
                Console.WriteLine($"{name}欢迎来杭州");
            }
        }
        public class SHHello : IShhHello
        {
            public void SayHello(string name)
            {
                Console.WriteLine($"{name}欢迎来上海");
            }
        }
    }
}

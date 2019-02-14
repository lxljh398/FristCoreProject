using System;
using System.Collections.Generic;
using System.Text;

namespace SyntacticSugar
{
    class delegateFun1
    {
        public delegate void GreetingDelegate(string name);
        static void Main(string[] args)
        {
            //GreetPeople("Jimmy Zhang", EnGreeting);
            //GreetPeople("张子阳", ChGreeting);
            GreetingDelegate greeting= EnGreeting;
            greeting += ChGreeting;
            GreetPeople("Jimmy Zhang", greeting);
            Console.ReadLine();
        }

        static void GreetPeople(string name, GreetingDelegate greetingDelegate)
        {
            greetingDelegate(name);
        }

        static void EnGreeting(string name)
        {
            Console.WriteLine("Morning, " + name);
        }

        static void ChGreeting(string name)
        {
            Console.WriteLine("早上好, " + name);
        }
    }
}

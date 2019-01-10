using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class AbstractMain
    {
        static void Main(string[] args)
        {

            Console.ReadKey();
        }

        abstract class AbsTest
        {
            public abstract int Age { get; set; }
            public abstract int Name { get; set; }
            public abstract int GetAge();
            public int ReAge() {
                return 1;
            }
        }

        class Test : AbsTest
        {
            public override int Age { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public override int Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public int NewAge { get; set; }
            public string NewName { get; set; }

            public override int GetAge()
            {
                throw new NotImplementedException();
            }
        }
    }
}

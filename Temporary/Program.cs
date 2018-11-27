using System;

namespace Temporary
{
    class Program
    {
        static void Main(string[] args)
        {
            //int a = 6 & 3;
            //int b = 6 | 3;

            //WeekDays wds = WeekDays.Monday | WeekDays.Tuesday | WeekDays.Sunday;
            //if ((wds & WeekDays.Monday) != 0)
            //{
            //    Console.WriteLine("Monday是其中的值");
            //}
            //if ((wds & WeekDays.Saturday) == 0)
            //{
            //    Console.WriteLine("Saturday不是其中的值");
            //}
            //Console.WriteLine(a);
            //Console.WriteLine(b);
            //Console.WriteLine(wds);
            //C c = new C();
            //c.Age = 2 | 4 | 5;
            //if ((c.Age & 2) != 0)
            //{

            //}
            //if (c.Age == (2 & 4 & 8 & 16))
            //{

            //}
            //D d = new D()
            //{
            //    Name = "dfd"
            //};
            //if (short.TryParse(c.Age?.ToString(), out short districtA))
            //{
            //    d.Age = districtA;
            //}


            //Console.WriteLine(ret(1, 2));
            //Console.WriteLine(ret(1, 1));
            //Console.WriteLine(ret(2, 2));
            //Console.WriteLine(ret(1, 3));
            //Console.WriteLine(ret(2, 3));
            //Console.WriteLine(ret(4, 3));
            //Console.WriteLine(ret(0, 3));


            //WeekDays wds = WeekDays.Monday | WeekDays.Tuesday | WeekDays.Sunday;
            //wds = wds & (~WeekDays.Monday);
            //Console.WriteLine(wds);
            //wds = wds | WeekDays.Monday;
            //Console.WriteLine(wds);


            int i = 1;
            Console.WriteLine("0x{0:x}", i << 33);
            Console.ReadLine();
        }

        public static int ret(int inputState, int dataState)
        {
            int state = 1 | 2 | 3;
            if ((inputState & state) != 0 && (dataState & state) != 0)
            {
                if (dataState == 3 || (inputState + dataState) == 3)
                {
                    dataState = 3;
                }
                else
                {
                    dataState = inputState;
                }
            }
            else
            {
                dataState = inputState;
            }
            return dataState;
        }


        public class C
        {
            public short? Age { get; set; }
        }

        public class D
        {
            public int? Age { get; set; }
            public string Name { get; set; }
        }
        [Flags]
        enum WeekDays
        {
            Monday = 0x1,
            Tuesday = 0x2,
            Wednesday = 0x4,
            Thursday = 0x8,
            Friday = 0x10,
            Saturday = 0x20,
            Sunday = 0x40
        }
    }
}

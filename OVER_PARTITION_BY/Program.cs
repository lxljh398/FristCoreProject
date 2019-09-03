using System;
using System.Linq;

namespace OVER_PARTITION_BY
{
    class Program
    {
        static void Main(string[] args)
        {
            var beatles = (new[] {
                new { id=1 , inst = "guitar" , name="john" },
                new { id=2 , inst = "guitar" , name="george" },
                new { id=3 , inst = "guitar" , name="paul" },
                new { id=4 , inst = "drums" , name="ringo" },
                new { id=5 , inst = "drums" , name="pete" }
                });


            var rnb = beatles
                    .OrderByDescending(x => x.id) // order by yyy
                    .GroupBy(x => x.inst)   // partition by xxx
                                            //.Select(group => new { Group = group, Count = group.Count() })
                    .SelectMany(e => e//.Select(v => v)
                        .Zip(Enumerable.Range(1, 1) /*ROW_NUMBER*/, (i, j) => new
                        {
                            i.inst,
                            i.name,
                            rn = j,
                            i.id
                        })
                    );

            var a = rnb.ToList();
            //GetChick();
        }

        public static void GetChick()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 33; j++)
                {
                    var a = 100 - i - j;
                    if ((5 * i) + (3 * j) + (a / 3.0f) == 100)
                        Console.WriteLine($"公鸡{i},母鸡{j}，小鸡{a}");
                }
            }
            Console.ReadLine();
        }
    }
}

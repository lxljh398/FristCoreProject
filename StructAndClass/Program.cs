using System;

namespace StructAndClass
{
    class Program
    {

        internal class PointClass
        {
            public PointClass(int x, int y)
            {
                X = x;
                Y = y;
            }
            public int X { get; set; }
            public int Y { get; set; }
        }


        internal struct PointStruct
        {
            public int X { get; set; }
            public int Y { get; set; }
            public PointStruct(int x, int y)
            {
                X = x;
                Y = y;
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("PointStruct =====");
            var pStruct = new PointStruct(10, 10);
            Console.WriteLine("初始值：x={0}，y={1}", pStruct.X, pStruct.Y);
            ModifyPointStruct(pStruct);
            Console.WriteLine("调用 ModifyPointStruct() 后的值：x={0}，y={1}", pStruct.X, pStruct.Y);
            Console.WriteLine();

            Console.WriteLine("PointClass =====");
            var pClass = new PointClass(10, 10);
            Console.WriteLine("初始值：x={0}，y={1}", pClass.X, pClass.Y);
            ModifyPointClass(pClass);
            Console.WriteLine("调用 ModifyPointClass() 后的值：x={0}，y={1}", pClass.X, pClass.Y);
            Console.Read();
        }


        private static void ModifyPointStruct(PointStruct point)
        {
            point = new PointStruct(30,60);
            Console.WriteLine("调用方法：ModifyPointStruct");
            point.X = 20;
            point.Y = 20;
            Console.WriteLine("修改成的值：x={0}, y={1}", point.X, point.Y);
        }

        private static void ModifyPointClass(PointClass point)
        {
            Console.WriteLine("调用方法：ModifyPointClass");
            point.X = 20;
            point.Y = 20;
            Console.WriteLine("修改成的值：x={0}, y={1}", point.X, point.Y);
        }
    }
}

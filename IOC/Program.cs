using System;

namespace IOC
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnderly underly = new Underly();
            underly.WriterLine();
            Console.ReadKey();
        }
    }

    public interface IUnderly
    {
        void WriterLine();
    }

    public class Underly : IUnderly
    {
        public void WriterLine()
        {
            Console.WriteLine("这是底层类型的输出");
        }
    }
}

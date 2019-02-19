using System;

namespace Domain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        //定义应用程序域
        public AppDomain Domain;
        public int ThreadId;
        //设置值
        public void SetDomainData(string vName, string vValue)
        {
            Domain.SetData(vName, (object)vValue);
            ThreadId = AppDomain.GetCurrentThreadId();
        }
        //获取值
        public string GetDomainData(string name)
        {
            return (string)Domain.GetData(name);
        }
        public static void DomainMainGo()
        {
            string DataName = "MyData";
            string DataValue = "Some Data to be stored";

            Console.WriteLine("Retrieving current domain");
            MyAppDomain Obj = new MyAppDomain();
            Obj.Domain = AppDomain.CurrentDomain;

            Console.WriteLine("Setting domain data");
            Obj.SetDomainData(DataName, DataValue);

            Console.WriteLine("Getting domain data");
            Console.WriteLine($"The Data found for key{DataName},is{Obj.GetDomainData(DataName)},running on thread id: {Obj.ThreadId}");
        }
    }
}

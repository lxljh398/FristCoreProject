using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqFunctionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstAddressOrPointXYLand = new List<int>() { 1, 2, 3, 4, 5, 6 };//地址
            List<int> CompanyLand = new List<int>() { 3, 4, 6, 7, 8 };//企业
            List<int> ContactLand = new List<int>() { 2, 3, 9 };//联系人
            List<int> DistanceLand = new List<int>() { 1, 4, 8, 10 };//范围



            //List<int> lstMarge = new List<int>();
            //lstMarge.AddRange(lstAddressOrPointXYLand);


            List<int> lstMarge = lstAddressOrPointXYLand;//List是引用类型，如果使用此语法则lstAddressOrPointXYLand的值会随着lstMarge的改变而改变


            CompanyLand = CompanyLand.Except(lstMarge).ToList();//排除级别高的重复数据
            lstMarge.AddRange(CompanyLand);//合并高级别的数据

            ContactLand = ContactLand.Except(lstMarge).ToList();
            lstMarge.AddRange(ContactLand);
            DistanceLand = DistanceLand.Except(lstMarge).ToList();

            Console.WriteLine();
        }
    }
}

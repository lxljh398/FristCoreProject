using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableExcept
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataTable table = new DataTable();
            //table.Columns.Add("strName", Type.GetType("System.String"));
            //table.Columns.Add("strSex", Type.GetType("System.String"));
            //table.Columns.Add("strEmail", Type.GetType("System.String"));

            //table.Rows.Add(new object[] { "Tom", "男", "Tom@atguigu.com" });
            //table.Rows.Add(new object[] { "Lucy", "女", "Lucy@atguigu.com" });
            //table.Rows.Add(new object[] { "Jack", "男", "Jack@atguigu.com" });
            //table.Rows.Add(new object[] { "lx", "男", "Jack@atguigu.com" });





            //DataTable table1 = new DataTable();
            //table1.Columns.Add("strName", Type.GetType("System.String"));
            //table1.Columns.Add("strSex", Type.GetType("System.String"));
            //table1.Columns.Add("strEmail", Type.GetType("System.String"));

            //table1.Rows.Add(new object[] { "Tom", "男", "Tom@atguigu.com" });
            //table1.Rows.Add(new object[] { "Lucy1", "女", "Lucy@atguigu.com" });
            //table1.Rows.Add(new object[] { "Jack2", "男", "Jack@atguigu.com" });

            //var normalReceive = table.AsEnumerable().Except(table1.AsEnumerable(), DataRowComparer.Default).CopyToDataTable();//正确结果
            //var normalReceive1 = table.AsEnumerable().Except(table1.AsEnumerable()).CopyToDataTable(); //AsEnumerable()方法延迟执行，不会立即执行。当你调用.AsEnumerable()的时候，实际上什么都没有发生




            ////堆栈问题
            //List<LandsByContactIDsOrAddressOrPointXY> lst = new List<LandsByContactIDsOrAddressOrPointXY>();
            //List<LandsByContactIDsOrAddressOrPointXY> lsts = new List<LandsByContactIDsOrAddressOrPointXY>();


            //List<LandsByContactIDsOrAddressOrPointXY> s = new List<LandsByContactIDsOrAddressOrPointXY>() {
            //    new LandsByContactIDsOrAddressOrPointXY{
            //        LandID = 18305,
            //    Address = "卫正大厦",
            //    DataType = ""
            //    }
            //};            
            //List<LandsByContactIDsOrAddressOrPointXY> ss = new List<LandsByContactIDsOrAddressOrPointXY>() {
            //    new LandsByContactIDsOrAddressOrPointXY{
            //        LandID = 18305,
            //    Address = "卫正大厦",
            //    DataType = ""
            //    }
            //};
            ////LandsByContactIDsOrAddressOrPointXY s1 = new LandsByContactIDsOrAddressOrPointXY()
            ////{
            ////    LandID = 18305,
            ////    Address = "卫正大厦",
            ////    DataType = ""
            ////};

            //lst.AddRange(s);
            ////lsts.Add(s1);
            //lsts.AddRange(ss);

            //lsts = lsts.Except(lst).ToList();


            List<int> s = new List<int>() {1,2,4};
            s.Add(3);
            string ids = string.Join(",", s.ToArray())?.TrimEnd(',');


            Console.WriteLine(ids);
        }

        public class LandsByContactIDsOrAddressOrPointXY
        {
            /// <summary>
            /// LandID
            /// </summary>
            public int LandID { get; set; }
            /// <summary>
            /// 地址
            /// </summary>
            public string Address { get; set; }
            /// <summary>
            /// 类别
            /// </summary>
            public string DataType { get; set; }
        }
    }
}

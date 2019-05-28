using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegexDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string RegexStr = string.Empty;

            #region 字符串查找

            string LinkA = "<a href=\"http://www.baidu.com\" target=\"_blank\">百度</a>";

            RegexStr = @"href=""[\S]+""";   // ""匹配"
            Match mt = Regex.Match(LinkA, RegexStr);

            Console.WriteLine("{0}。", LinkA);
            Console.WriteLine("获得href中的值：{0}。", mt.Value);

            RegexStr = @"<h[^23456]>[\S]+<h[1]>";    //<h[^23456]>:匹配h除了2,3,4,5,6之中的值,<h[1]>:h匹配包含括号内元素的字符
            Console.WriteLine("{0}。GetH1值：{1}", "<H1>标题<H1>", Regex.Match("<H1>标题<H1>", RegexStr, RegexOptions.IgnoreCase).Value);
            Console.WriteLine("{0}。GetH1值：{1}", "<h2>小标<h2>", Regex.Match("<h2>小标<h2>", RegexStr, RegexOptions.IgnoreCase).Value);
            //RegexOptions.IgnoreCase:指定不区分大小写的匹配。

            RegexStr = @"ab\w+|ij\w{1,}";   //匹配ab和字母 或 ij和字母
            Console.WriteLine("{0}。多选结构：{1}", "abcd", Regex.Match("abcd", RegexStr).Value);
            Console.WriteLine("{0}。多选结构：{1}", "efgh", Regex.Match("efgh", RegexStr).Value);
            Console.WriteLine("{0}。多选结构：{1}", "ijk", Regex.Match("ijk", RegexStr).Value);

            RegexStr = @"张三?丰";    //?匹配前面的子表达式零次或一次。
            Console.WriteLine("{0}。可选项元素：{1}", "张三丰", Regex.Match("张三丰", RegexStr).Value);
            Console.WriteLine("{0}。可选项元素：{1}", "张丰", Regex.Match("张丰", RegexStr).Value);
            Console.WriteLine("{0}。可选项元素：{1}", "张飞", Regex.Match("张飞", RegexStr).Value);

            /* 
             例如：
            July|Jul　　可缩短为　　July?
            4th|4　　   可缩短为　　4(th)?
            */

            //匹配特殊字符
            RegexStr = @"Asp\.net";    //匹配Asp.net字符，因为.是元字符他会匹配除换行符以外的任意字符。这里我们只需要他匹配.字符即可。所以需要转义\.这样表示匹配.字符
            Console.WriteLine("{0}。匹配Asp.net字符：{1}", "Java Asp.net SQLServer", Regex.Match("Java Asp.net SQLServer", RegexStr).Value);
            Console.WriteLine("{0}。匹配Asp.net字符：{1}", "C# Java", Regex.Match("C# Java", RegexStr).Value);


            string RegexStr1 = @"1[345678]\d{9}";  //取手机号
            var aaa = Regex.Match("ab13735471883cd", RegexStr1).Value;
            Console.WriteLine(Regex.Match("ab13735471883cd", RegexStr1).Value);

            var result = Regex.Match("3.13800138000/BBS 中国移动", "(1(([35][0-9])|(47)|8[0126789]))\\d{8}").Value;
            Console.WriteLine(result);


            string Resume = "基本信息姓名:CK|求职意向:.NET软件工程师|性别:男|学历:本专|出生日期:1988-08-08|户籍:湖北.孝感|E - Mail:9245162@qq.com|手机:15000000000";
            RegexStr = @"姓名:(?<name>[\S]+)\|\S+性别:(?<sex>[\S]{1})\|学历:(?<xueli>[\S]{1,10})\|出生日期:(?<Birth>[\S]{10})\|[\s\S]+手机:(?<phone>[\d]{11})";
            Match matc = Regex.Match(Resume, RegexStr);
            Console.WriteLine("姓名：{0},手机号：{1}", matc.Groups["name"].ToString(), matc.Groups["phone"].ToString());
            #endregion

            var ttt = DateTime.Parse("2019-10-10 12:10");
            Console.WriteLine(aaa);
            var bbb = DateTime.Parse(ttt.ToShortDateString()).AddDays(1);
            Console.WriteLine(bbb);

            Console.ReadLine();



        }
    }
}

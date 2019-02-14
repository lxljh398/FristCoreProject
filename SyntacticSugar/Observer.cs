using System;
using System.Collections.Generic;
using System.Text;

namespace SyntacticSugar
{
    class Observer
    {
        static void Main(string[] args)
        {
            Heater heater = new Heater();
            heater.BoilEvent += heater.MakeAlert;    //注册方法
            heater.BoilEvent += heater.ShowMsg;       //注册静态方法
            heater.BoilWater();   //烧水，会自动调用注册过对象的方法
            Console.ReadKey();
        }
    }

    /// <summary>
    /// List扩展方法
    /// </summary>
    public static class ListExtend
    {
        //声明自定义泛型委托
        public delegate void PrintT<T>(T t);

        public static void TEach<T>(this List<T> list, PrintT<T> pt)
        {
            foreach (T t in list)
            {
                pt(t);
            }
        }
    }

    class Heater
    {
        public int temperature; // 水温
        public delegate void BoilHandler(int param);
        public event BoilHandler BoilEvent;
        // 烧水
        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                temperature = i;
                if (temperature > 95)
                {
                    if (BoilEvent != null)
                    {
                        BoilEvent(temperature);
                    }
                }
            }
        }

        // 发出语音警报
        public void MakeAlert(int param)
        {
            Console.WriteLine("Alarm：嘀嘀嘀，水已经 {0} 度了：", param);
        }

        // 显示水温
        public void ShowMsg(int param)
        {
            Console.WriteLine("Display：水快开了，当前温度：{0}度。", param);
        }
    }
}

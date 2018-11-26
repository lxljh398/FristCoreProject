using JiebaNet.Segmenter;
using System;

namespace JieBa
{
    class Program
    {
        static void Main(string[] args)
        {

            var segmenter = new JiebaSegmenter();
            var segments = segmenter.Cut("我来到北京清华大学", cutAll: true);
            Console.WriteLine("【全模式】：{0}", string.Join("/ ", segments));
            Console.ReadKey();
        }
    }
}

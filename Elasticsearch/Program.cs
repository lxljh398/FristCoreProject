using Nest;
using System;

namespace Elasticsearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var node = new Uri("http://myserver:9200");
            var setting = new ConnectionSettings(node);
            var client = new ElasticClient(setting);






            var settings = new ConnectionSettings().DefaultIndex("d");


            Console.WriteLine("Hello World!");
        }


    }
}

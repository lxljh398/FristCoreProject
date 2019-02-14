using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitmqSend
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            IConnectionFactory conFactory = new ConnectionFactory//创建连接工厂对象
            {
                HostName = "127.0.0.1",//IP地址
                Port = 5672,//端口号
                UserName = "lixin",//用户账号
                Password = "123456"//用户密码
            };
            //using (IConnection con = conFactory.CreateConnection())//创建连接对象
            //{
            //    using (IModel channel = con.CreateModel())//创建连接会话对象
            //    {
            //        String queueName = String.Empty;
            //        if (args.Length > 0)
            //            queueName = args[0];
            //        else
            //            queueName = "lixin_Rabbit";
            //        //声明一个队列
            //        channel.QueueDeclare(
            //          queue: queueName,//消息队列名称
            //          durable: false,//是否缓存
            //          exclusive: false,
            //          autoDelete: false,
            //          arguments: null
            //           );
            //        while (true)
            //        {
            //            Console.WriteLine("消息内容:");
            //            String message = Console.ReadLine();
            //            //消息内容
            //            byte[] body = Encoding.UTF8.GetBytes(message);
            //            //发送消息
            //            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
            //            Console.WriteLine("成功发送消息:" + message);
            //        }
            //    }
            //}

            //创建连接
            var connection = conFactory.CreateConnection();
            //创建通道
            var channel = connection.CreateModel();
            //声明一个队列
            channel.QueueDeclare("hello", false, false, false, null);

            Console.WriteLine("\nRabbitMQ连接成功，请输入消息，输入exit退出！");

            string input;
            do
            {
                input = Console.ReadLine();

                var sendBytes = Encoding.UTF8.GetBytes(input);
                //发布消息
                channel.BasicPublish("", "hello", null, sendBytes);

            } while (input.Trim().ToLower() != "exit");
            channel.Close();
            connection.Close();
        }
    }
}

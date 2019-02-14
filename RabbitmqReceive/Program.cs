using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace RabbitmqReceive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            IConnectionFactory connFactory = new ConnectionFactory//创建连接工厂对象
            {
                HostName = "127.0.0.1",//IP地址
                Port = 5672,//端口号
                UserName = "lixin",//用户账号
                Password = "123456"//用户密码
            };
            //using (IConnection conn = connFactory.CreateConnection())
            //{
            //    using (IModel channel = conn.CreateModel())
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
            //        //创建消费者对象
            //        var consumer = new EventingBasicConsumer(channel);
            //        consumer.Received += (model, ea) =>
            //        {
            //            byte[] message = ea.Body;//接收到的消息
            //            Console.WriteLine("接收到信息为:" + Encoding.UTF8.GetString(message));
            //        };
            //        //消费者开启监听
            //        channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
            //        Console.ReadKey();
            //    }
            //}

            //创建连接
            var connection = connFactory.CreateConnection();
            //创建通道
            var channel = connection.CreateModel();

            //事件基本消费者
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);

            //接收到消息事件
            consumer.Received += (ch, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body);

                Console.WriteLine($"收到消息： {message}");

                Console.WriteLine($"收到该消息[{ea.DeliveryTag}] 延迟10s发送回执");
                Thread.Sleep(3000);
                //确认该消息已被消费
                channel.BasicAck(ea.DeliveryTag, false);
                Console.WriteLine($"已发送回执[{ea.DeliveryTag}]");
            };
            //启动消费者 设置为手动应答消息
            channel.BasicConsume("hello", true, consumer);
            Console.WriteLine("消费者已启动");
            Console.ReadKey();
            channel.Dispose();
            connection.Close();
        }
    }
}

﻿using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQ.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "m1",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (ModuleHandle, ea) =>
                 {
                     var body = ea.Body.ToArray();
                     var message = Encoding.UTF8.GetString(body);
                     Console.WriteLine("Received {0} ", message);
                 };
                channel.BasicConsume(queue: "m1", autoAck: true, consumer: consumer);
            }
        }
    }
}

using Consumidor.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace Consumidor
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Criando a fila
                channel.QueueDeclare(queue: "Messages",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                                
                Console.WriteLine("Esperando pela mensagem...");

                // Consumindo a mensagem
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (sender, ea) =>
                {
                    var contentArray = ea.Body.ToArray();
                    var contentString = Encoding.UTF8.GetString(contentArray);                    
                    Console.WriteLine(" Recebido {0}", contentString);
                };

                channel.BasicConsume(queue: "Messages",
                                     autoAck: true,
                                     consumer: consumer);
                Console.ReadLine();
            }
        }
    }
}

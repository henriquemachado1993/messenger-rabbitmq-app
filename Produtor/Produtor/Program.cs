using Newtonsoft.Json;
using Produtor.Model;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading;

namespace Produtor
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Cria a fila
                channel.QueueDeclare(queue: "Messages",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                int count = 0;
                while (true)
                {
                    // Monta a mensagem
                    var message = $"{count++} Guid: {Guid.NewGuid()}";

                    // Transforma a mensagem em bytes
                    string stringfiedmessage = JsonConvert.SerializeObject(message);
                    var body = Encoding.UTF8.GetBytes(stringfiedmessage);

                    // Publica a mensagem na fila
                    channel.BasicPublish(exchange: "",
                                         routingKey: "Messages",
                                         basicProperties: null,
                                         body: body);
                    Console.WriteLine(" Enviado {0}", message);
                    Thread.Sleep(200);
                }                
            }
        }
    }
}

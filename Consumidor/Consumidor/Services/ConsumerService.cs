using Consumidor.Contracts;
using Consumidor.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consumidor.Services
{
    public class ConsumerService : IConsumerService
    {
        private readonly RabbitMqConfig _config;
        private readonly ConnectionFactory _factory;

        public ConsumerService()
        {
            _config = new RabbitMqConfig();
            _factory = new ConnectionFactory()
            {
                HostName = _config.Host
            };
        }

        public void ReadMessages()
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Criando a fila
                channel.QueueDeclare(queue: _config.Fila,
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

                channel.BasicConsume(queue: _config.Fila,
                                     autoAck: true,
                                     consumer: consumer);

                Console.ReadLine();
            }
        }
    }
}

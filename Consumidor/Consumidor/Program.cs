using Consumidor.Contracts;
using Consumidor.Factory;
using Consumidor.Model;
using Consumidor.Services;
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
            var consumerService = FactoryService.GetConsumerService();
            consumerService.ReadMessages();

            Console.ReadLine();            
        }
    }
}

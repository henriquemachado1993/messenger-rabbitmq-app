using Consumidor.Contracts;
using Consumidor.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consumidor.Factory
{
    public static class FactoryService
    {
        public static IConsumerService GetConsumerService()
        {
            return new ConsumerService();
        }
    }
}

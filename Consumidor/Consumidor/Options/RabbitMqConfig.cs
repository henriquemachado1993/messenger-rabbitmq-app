using System;
using System.Collections.Generic;
using System.Text;

namespace Consumidor.Options
{
    public class RabbitMqConfig
    {
        public string Host { get; set; } = "localhost";
        public string Fila { get; set; } = "Messages";
    }
}

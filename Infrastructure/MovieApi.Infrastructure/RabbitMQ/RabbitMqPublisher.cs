using Microsoft.Extensions.Configuration;
using MovieApi.Application.Interfaces.Events;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Infrastructure.RabbitMQ
{
    public class RabbitMqPublisher : IMessagePublisher
    {
        private readonly IConfiguration configuration;

        public RabbitMqPublisher(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task PublishAsync<T>(T message) where T : class
        {
            ConnectionFactory factory = new();
            factory.Uri = new(configuration["RabbitMQ:Uri"]);

            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();

            var queueName = typeof(T).Name;
            channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);


             channel.BasicPublish(exchange: "",
                                  routingKey: queueName,
                                  body: body);

            return;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MovieApi.Application.DTOs;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using MovieApi.Domain.Entities;
using MovieApi.Application.Interfaces.Events;
using Newtonsoft.Json;

namespace MovieApi.Infrastructure.RabbitMQ
{
    public class EmailConfirmationConsumer : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration configuration;

        public EmailConfirmationConsumer(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            this.configuration = configuration;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            ConnectionFactory factory = new();
            factory.Uri = new(configuration["RabbitMQ:Uri"]);

            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();

            channel.QueueDeclare(queue: nameof(EmailConfirmationMessage),
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (sender, e) =>
            {
                using var scope = _serviceProvider.CreateScope();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var emailSender = scope.ServiceProvider.GetRequiredService<IEmailSender>();

                byte[] body = e.Body.ToArray();
                string messageJson = Encoding.UTF8.GetString(body);
                var message = JsonConvert.DeserializeObject<EmailConfirmationMessage>(messageJson);

                var user = await userManager.FindByEmailAsync(message.Email);
                if (user != null)
                {
                    var encodedToken = Uri.EscapeDataString(message.Token);
                    var confirmLink = $"http://localhost:5247/api/Auth/ConfirmEmail/confirm-email?email={message.Email}&token={encodedToken}";


                    string subject = "Email Doğrulama";
                    string bodyContent = $"Lütfen hesabınızı doğrulamak için <a href='{confirmLink}'>buraya tıklayın</a>.";

                    await emailSender.SendEmailAsync(user.Email, subject, bodyContent);
                }
            };

            channel.BasicConsume(queue: nameof(EmailConfirmationMessage),
                                 autoAck: true,
                                 consumer: consumer);

            return Task.CompletedTask;
        }
    }
}

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace monitor.server
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory
            {
                UserName = "adm",
                Password = "força1",
                //factory.VirtualHost = vhost;
                HostName = "localhost"
            };

            IConnection conn = factory.CreateConnection();
            IModel channel = conn.CreateModel();

            channel.ExchangeDeclare("plugin_x", ExchangeType.Fanout);
            Int64 pub_count = 0;

            while (!stoppingToken.IsCancellationRequested)
            {
                byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes($"[{ pub_count++ }] Plugin X send status at: {DateTimeOffset.Now}");
                
                channel.BasicPublish("plugin_x", "*", true, null, messageBodyBytes);
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(5000, stoppingToken);
            }

            channel.Close();
            conn.Close();
        }
    }
}

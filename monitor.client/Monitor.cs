using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monitor.client
{
    public partial class Monitor : Form
    {

        private readonly IConnection connectionMB;
        private readonly IModel channelMB;

        private delegate void SafeCallDelegate(string text);

        public Monitor()
        {
            InitializeComponent();
            var factory = new ConnectionFactory
            {
                UserName = "adm",
                Password = "força1",
                //factory.VirtualHost = vhost;
                HostName = "localhost"
            };

            connectionMB = factory.CreateConnection();
            channelMB = connectionMB.CreateModel();
            //channelMB.ExchangeDeclare("plugin_x", ExchangeType.Fanout);

            channelMB.QueueDeclare("client_1");


            channelMB.QueueBind("client_1", "plugin_x", "*", null);

            var consumer = new EventingBasicConsumer(channelMB);

            consumer.Received += (ch, ea) =>
            {
                var body = ea.Body.ToArray();
                // copy or deserialise the payload
                // and process the message
                // ...

                WriteTextSafe(System.Text.Encoding.UTF8.GetString(body)   + $"(delivery: {DateTime.Now}-{DateTime.Now:fff})"  + Environment.NewLine); ;

                channelMB.BasicAck(ea.DeliveryTag, true);
            };
            // this consumer tag identifies the subscription
            // when it has to be cancelled
            String consumerTag = channelMB.BasicConsume("client_1", true, consumer);

           

        }

        private void WriteTextSafe(string text)
        {
            if (txtMonitor.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteTextSafe);
                txtMonitor.Invoke(d, new object[] { text });
            }
            else
            {
                txtMonitor.Text += text;
            }
        }

        private void Monitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            connectionMB.Close();
            channelMB.Close();
        }
    }
}

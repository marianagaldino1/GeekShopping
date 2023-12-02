using GeekShopping.MessageBus;
using GeekShopping.PaymentAPI.Messages;
using Microsoft.AspNetCore.Components;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GeekShopping.PaymentAPI.RabbitMQSender
{
    public class RabbitMqMessageSender : IRabbitMqMessageSender
    {
        private readonly string _hostName;
        private readonly string _password;
        private readonly string _userName;
        private IConnection _connection;
        private const string ExchangeName = "FanoutPaymentUpdateExchange";

        public RabbitMqMessageSender()
        {
            _hostName = "localhost";
            _password = "guest";
            _userName = "guest";
        }
        public void SendMessage(BaseMessage message)
        {
            if(ConnectionExist())
            {
                using var channel = _connection.CreateModel();
                channel.ExchangeDeclare(ExchangeName, ExchangeType.Fanout, durable:false);
                byte[] body = GetMessageAsByteArray(message);
                channel.BasicPublish(exchange: ExchangeName,"", basicProperties: null, body: body);
            }
        }

        private byte[] GetMessageAsByteArray(object message)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize((UpdatePaymentResultMessage)message, options);
            var body = Encoding.UTF8.GetBytes(json);
            return body;
        }
        private void CreateConnection()
        {
            try 
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostName,
                    UserName = _userName,
                    Password = _password
                };

                _connection = factory.CreateConnection();

            }
            catch(Exception) { throw; }
        }
        private bool ConnectionExist ()
        {
            if (_connection == null)
            {
                return true;
            }
            CreateConnection();
            return _connection != null;
        }

      
    }
}

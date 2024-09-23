using Newtonsoft.Json;
using System.Text;
using RabbitMQ.Client;
using OT.Assessment.App.Reposistory.IReposistory;
using OT.Assessment.App.Models;

namespace OT.Assessment.App.Reposistory
    {
    public class RabbitMQReposistory: IRabbitMQReposistory
        {
        private readonly IConnection _rabbitMqConnection;
        IModel channel;
        public string queueName= "wager_events";
        public RabbitMQReposistory()
            {
            _rabbitMqConnection = CreateRabbitMqConnection();
            channel=_rabbitMqConnection.CreateModel();
            }

        public bool SaveWagerEventToRabbitMq(WagerEventModel wagerEvent)
            {

            try
                {
                //using var channel = _rabbitMqConnection.CreateModel();
                channel.QueueDeclare(queueName, true, false, false);
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(wagerEvent));
                channel.BasicPublish("", queueName, body: body);
                }
            catch (Exception ex)
                {
                Console.WriteLine($"Request:{0}, Errror{1}", wagerEvent, ex.Message);
                return false;
                }
            return true;
            }

        private IConnection CreateRabbitMqConnection( )
            {
            var factory = new ConnectionFactory { HostName = "localhost" };
            return factory.CreateConnection();
            }
        
        }

    }

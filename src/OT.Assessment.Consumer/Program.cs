using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using OT.Assessment.Consumer.Data;
using OT.Assessment.Data.DataAccess;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.EntityFrameworkCore.SqlServer;
using OT.Assessment.Reposistory;
using OT.Assessment.Reposistory.IReposistory;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config =>
    {
        config.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
    })
    .ConfigureServices((context, services) =>
    {
        //configure services        
      
    })
    .Build();

var service = host.Services.CreateScope();
var Config = host.Services.GetRequiredService<IConfiguration>();
string connectionString = Config.GetConnectionString("DatabaseConnection");

var collection = new ServiceCollection();
IServiceCollection serviceCollection = collection.AddScoped<IWagerEventService, WagerEventService>();
collection.AddScoped<IPlayerReposistory, PlayerReposistory>();
collection.AddScoped<ApplicationDbContext>();
collection.AddDbContext<AssessmentDbContext>(
    options =>
    options.UseSqlServer(connectionString)
    );
collection.AddScoped<IWagerEventReposistory, WagerEventReposistory>();

var provider = collection.BuildServiceProvider();
var serviceProvider = provider.CreateScope().ServiceProvider;

var logger = host.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Application started {time:yyyy-MM-dd HH:mm:ss}", DateTime.Now);



string nameOfQueue = Config.GetValue<string>("QueueName");
string hostName = Config.GetValue<string>("HostName");

logger.LogInformation("Looking for messges from the queue:" + nameOfQueue + " {time:yyyy-MM-dd HH:mm:ss}", DateTime.Now);

var factory = new ConnectionFactory { HostName = hostName };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: nameOfQueue,
                     durable: true,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

logger.LogInformation(" [*] Waiting for messages.");

var consumer = new EventingBasicConsumer(channel);
consumer.Received += ProcessReceivedMessage;

channel.BasicConsume(queue: nameOfQueue,
                     autoAck: true,
                     consumer: consumer);
await host.RunAsync();
logger.LogInformation("Application ended {time:yyyy-MM-dd HH:mm:ss}", DateTime.Now);

 void ProcessReceivedMessage(object model, BasicDeliverEventArgs ea)
    {
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    string connectionString = Config.GetConnectionString("DatabaseConnection");
    WagerEventModel wagerEventModel = MapMessageToObject(message);
    if (!(wagerEventModel == null))
        {
        IWagerEventService wagerEventService = provider.GetService<IWagerEventService>();
        wagerEventService.ConnectionString = connectionString;
        Player player= wagerEventService.ExtractPlayer(wagerEventModel);
        if (player != null)
            {
            if (!wagerEventService.PlayeExists(player))
                {
                //Code to add the player into a dataase
                wagerEventService.AddNewPlayer(player);
                }
            }
        WagerEventModel storeResult = wagerEventService.SavePlayeWagerRecord(wagerEventModel);
        if(storeResult == null)
            {
            logger.LogInformation($"Could not store wager record due to an error.");
            }
        }
    logger.LogInformation($" [x] Received by function {message}.");    
    }

WagerEventModel MapMessageToObject(string message)
    {
    WagerEventModel eventModel = new WagerEventModel();    
    var jsonDoc = JsonDocument.Parse(message);
    var rootElement=jsonDoc.RootElement;

    try
        {
            eventModel.Id = rootElement.GetProperty("Id").GetInt32();
            eventModel.AccountId = Guid.Parse(rootElement.GetProperty("AccountId").ToString());
            eventModel.ExternalReferenceId = Guid.Parse(rootElement.GetProperty("ExternalReferenceId").ToString());
            eventModel.BrandId = Guid.Parse(rootElement.GetProperty("BrandId").ToString());
            eventModel.TransactionId = Guid.Parse(rootElement.GetProperty("TransactionId").ToString());
            eventModel.WagerId = Guid.Parse(rootElement.GetProperty("WagerId").ToString());
            eventModel.Duration = long.Parse(rootElement.GetProperty("Duration").ToString());
            eventModel.SessionData = rootElement.GetProperty("SessionData").ToString();
            eventModel.Username = rootElement.GetProperty("Username").ToString();
            eventModel.Theme = rootElement.GetProperty("Theme").ToString();
            eventModel.NumberOfBets = short.Parse(rootElement.GetProperty("NumberOfBets").ToString());
            eventModel.CountryCode = rootElement.GetProperty("CountryCode").ToString();
            eventModel.CreatedDateTime = DateTimeOffset.Parse(rootElement.GetProperty("CreatedDateTime").ToString());
            eventModel.Amount = decimal.Parse(rootElement.GetProperty("Amount").ToString());
            eventModel.GameName = rootElement.GetProperty("GameName").ToString();
            eventModel.Provider = rootElement.GetProperty("Provider").ToString();
            eventModel.WagerId = Guid.Parse(rootElement.GetProperty("TransactionTypeId").ToString());
        }
    catch (Exception ex)
        {
        logger.LogInformation($"An error occured while processing data, error is :{ex}");
        return null;
        }
    
    return eventModel;
    }
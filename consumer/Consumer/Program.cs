// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Text.Json;
using Consumer;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var connectionFactory = new ConnectionFactory();
using var connection = connectionFactory.CreateConnection();
using var channel = connection.CreateModel();
const string messageQueueName = "fooMessages";

channel.QueueDeclare(
    queue: messageQueueName,
    durable: true, // Our use case needs to survive resets
    exclusive: false, // Don't set this to true, while we do want exclusivity for our use case it also auto deletes the queue on the connection closing. No bueno
    autoDelete: false,
    arguments: null
);

// setup a consumer
var consumer = new EventingBasicConsumer(channel);

// This is the work we will do with a message
consumer.Received += (model, ea) =>
{
    var bytes = ea.Body.ToArray();
    var message = JsonSerializer.Deserialize<Message>(Encoding.UTF8.GetString(bytes), JsonSerializationDefaults.DefaultOptions);
    if (message == null)
    {
        return;
    }

    Console.WriteLine(
        $"Received message from User#{message.SendingUserId}, Priority: {(message.IsHighPriority ? "High" : "Normal")} : {message.SomeMessage}");
};

// turn on the consumer
channel.BasicConsume(
    queue: messageQueueName,
    autoAck: true, // we'll just let it auto-acknowledge as soon as we rec the message. Not ideal but we can manually take control of this for our use case.
    consumer: consumer
);

Console.WriteLine(" Press [return] to exit.");
Console.ReadLine();
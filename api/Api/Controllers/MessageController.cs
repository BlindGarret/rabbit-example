using System.Net;
using System.Text;
using System.Text.Json;
using Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/messages")]
public class MessageController : ControllerBase
{
    private readonly IConnection m_connection;

    public MessageController(IConnection connection)
    {
        m_connection = connection;
    }

    [HttpPost]
    [ProducesResponseType((int) HttpStatusCode.OK)]
    public ActionResult EnqueueMessage(MessagePayloadDto payload)
    {
        const string messageQueueName = "fooMessages";
        using var channel = m_connection.CreateModel();
        channel.QueueDeclare(
            queue: messageQueueName,
            durable: true, // Our use case needs to survive resets
            exclusive: false, // Don't set this to true, while we do want exclusivity for our use case it also auto deletes the queue on the connection closing. No bueno
            autoDelete: false,
            arguments: null
        );

        channel.BasicPublish(
            exchange: "",
            routingKey: messageQueueName,
            basicProperties: null,
            body: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(payload, JsonSerializationDefaults.DefaultOptions))
        );

        return Ok();
    }
}
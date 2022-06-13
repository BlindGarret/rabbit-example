namespace Api.Dtos;

public class MessagePayloadDto
{
    public string SomeMessage { get; set; } = "";

    public bool IsHighPriority { get; set; }

    public int SendingUserId { get; set; }
}
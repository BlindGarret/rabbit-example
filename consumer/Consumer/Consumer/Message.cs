namespace Consumer;

public class Message
{
    public string SomeMessage { get; set; } = "";

    public bool IsHighPriority { get; set; }

    public int SendingUserId { get; set; }
}
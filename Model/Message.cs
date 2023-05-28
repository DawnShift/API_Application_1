namespace API_Application_1.Model
{
    public class Message
    {
        public Message()
        {
            Id = Guid.NewGuid();
        }
        public Message(string message)
        {
            Text = message;
        }
        public Guid Id { get; set; }
        public string? Text { get; set; }
    }
}

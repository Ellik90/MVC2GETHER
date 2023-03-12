namespace Models;
public class Message
{
    int Id { get; set; }
    string Sender { get; set; }
    public string Content { get; set; }
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    DateTime Created { get; set; }

     public Message( string content)
    {
        Content = content;
        Created = DateTime.Now;
    }
    public Message () {}

    public string MessageTostring()
    {
        return $"{Sender}: {Content}";
    }
}
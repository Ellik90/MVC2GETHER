namespace Models;
using Data;
public class MessageService 
{
    MessageDB _messageDb;
    List<Message> allMessages = new();
    Message message = new();
    public MessageService(MessageDB messageDB)
    {
        _messageDb = messageDB;
    }
    public MessageService() { }

    // public List<User> GetMySenders(int id)
    // {
    //     List<User> users = _messageHandeler.GetMySenders(id);
    //     return users;
    // }
    
    public void MakeMessage(Message message)
    {
        _messageDb.CreateMessage(message);
    }

    public List<Message> GetOneMessageConversation(User user, int id2)
    {
        List<Message> messages = _messageDb.GetMyMessages(user, id2);
        return messages;
    }


}
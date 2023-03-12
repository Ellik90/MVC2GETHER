namespace Models;
using Data;
public class MessageService 
{
    MessageDB _messageDB;
    List<Message> allMessages = new();
    Message message = new();
    public MessageService(MessageDB messageDB)
    {
        _messageDB = messageDB;
    }
    public MessageService() { }

    // public List<User> GetMySenders(int id)
    // {
    //     List<User> users = _messageHandeler.GetMySenders(id);
    //     return users;
    // }
    
    public void MakeMessage(Message message)
    {
        _messageDB.CreateMessage(message);
    }

    public List<Message> GetOneMessageConversation(User user, int id2)
    {
        List<Message> messages = _messageDB.GetMyMessages(user, id2);
        return messages;
    }


}
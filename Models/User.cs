namespace Models;


public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string? Gender { get; set; }
    public string Age { get; set; }
    public string Email { get; set; }
    public string PassWord { get; set; }

    public User(string name, string lastName, string gender, string age, string email, string passWord)
    {

    }
    public User()
    {

    }


}
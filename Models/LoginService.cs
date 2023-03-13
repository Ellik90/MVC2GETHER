namespace MVC2GETHER.Models;
using Data;
public class LoginService 
{
    UserDB _userDB;

    public LoginService(UserDB userDB)
    {
        _userDB = userDB;
    }


    public User UserLogIn(User user)
    {
        if (_userDB.UserEmailExists(user.Email) == true)
        {
            Console.WriteLine("Valid email");
        }
        else
        {
            Console.WriteLine("Unvalid email");
        }
        
        return user;

    }

    public int UserLoginIsValid(string email, string password)
    {
        try
        {
        return _userDB.UserLogInExists(email, password);
        }
        catch(Exception e)
        {
            return 0;
        }
    }
}
namespace Models;
using Data;
public class LoginService 
{
    User _user;
    UserDB _userDB;

    public LoginService(User user, UserDB userDB)
    {
        _user = user;
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

    public int UserLoginIsValid(User user)
    {
        return _userDB.UserLogInExists(user);
    }
}
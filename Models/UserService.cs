namespace MVC2GETHER.Models;
using Data;

public class UserService 
{

    UserDB _userDB;
    public UserService(UserDB userDB)
    {
        _userDB = userDB;
    }
    public UserService() { }

    public bool UpdateUserEmail(User user, string email)
    {
        bool rows = false;
        if (_userDB.UpdateUserEmail(user, email) < 1)
        {
            rows = true;
        }
        return rows;
    }

    public bool UpdateUserPassword(User user, string password)
     {
        bool rows = false;
        if (_userDB.UpdateUserPassword(user, password) < 1)
        {
            rows = true;
        }
        return rows;
    }

    public bool DeleteUser(User user)
    {
        int rows = 0;
        rows = _userDB.DeleteUser(user);
        if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int CreateUser(User user)
    {
        int id = 0;
        id = _userDB.CreateUser(user);
        return id;
    }


    public User GetUser(int id)
    {
        User user = _userDB.GetUser(id);
        if (user != null)
        {
            return user;
        }
        else
        {
            return null;
        }

    }
    
    public bool CheckUserEmailExists(string email)
    {
        bool rows = false;

        if (_userDB.UserEmailExists(email) == true) 
        {
            rows = true;
        }
        return rows;
    }
    public bool CheckUserPersonalNumberExists(string personalNumber)
    {
        bool rows = false;

        if (_userDB.UserPersonalNumberExists(personalNumber) == true)
        {
            rows = true;
        }
        return rows;
    }
    public bool UpdateUserDescription(User user, string description)
    {

        bool rows = false;
        if (_userDB.UpdateUserDescription(user, description) < 1)
        {
            rows = true;
        }
        return rows;
    }

}
using Dapper;
using MySqlConnector;
using Models;
namespace Data;
public class UserDB 
{
    public int CreateUser(User user)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO user_account(first_name, last_name, gender, age, personal_number, email, pass_word,land_scape_id)" +
            "VALUES(@Name,@LastName,@Gender,@Age,@PersonalNumber,@Email,@PassWord,@landScapeId);";
            rows = connection.ExecuteScalar<int>(query, param: user);
        }
        return rows;
    }

    public int DeleteUser(User user)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "DELETE FROM user_account WHERE id = @id ";
            rows = connection.ExecuteScalar<int>(query, param: user);
        }
        return rows;
    }
    
    public bool UserEmailExists(string email)
    {
        bool rows = true;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "SELECT * FROM user_account WHERE email = @email";
            rows = connection.ExecuteScalar<bool>(query, new { @email = email });
        }
        return rows;
    }

    public bool UserPersonalNumberExists(string personalNumber)
    {
        bool rows = true;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "SELECT * FROM user_account WHERE personal_number = @PersonalNumber";
            rows = connection.ExecuteScalar<bool>(query, new { @personalNumber = personalNumber });
        }
        return rows;
    }

    public int UserLogInExists(User user)
    {
        int id = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string? query = "SELECT id AS 'Id' FROM user_account WHERE email = @email AND pass_word = @password;";
            id = connection.ExecuteScalar<int>(query, new { @email = user.Email, @password = user.PassWord });
            return id;
        }
    }

    public int UpdateUserDescription(User user, string description)
    {
        int id = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string? query = "UPDATE user_account SET about_me = @AboutMe WHERE id = @Id ";
            id = connection.ExecuteScalar<int>(query, new { @AboutMe = description, @id = user.Id });
            return id;
        }
    }

    public int UpdateUserEmail(User user, string email)
    {
        int id = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string? query = "UPDATE user_account SET email = @email WHERE id = @Id ";
            id = connection.ExecuteScalar<int>(query, new { @email = email, @id = user.Id });
            return id;
        }
    }

    public int UpdateUserPassword(User user, string passWord)
    {
        int id = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string? query = "UPDATE user_account SET pass_word = @PassWord WHERE id = @Id ";
            id = connection.ExecuteScalar<int>(query, new { @PassWord = passWord, @id = user.Id });
            return id;
        }
    }

    public User GetUser(int id)
    {
        User user = new();
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = " SELECT u.id AS 'id', u.personal_number AS 'personalNumber', u.first_name AS 'name', u.email AS 'email', u.pass_word AS 'password', l.name AS 'landscape'" +
                           " FROM user_account u INNER JOIN landscape l ON u.land_scape_id = l.id WHERE u.id = @id;";
            try
            {
                user = connection.QuerySingle<User>(query, new { @id = id });
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            return user;
        }
    }


    // public List<User> GetAllUsers()
    // {
    //     List<User> users = new();
    //     using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
    //     {
    //         string? query = "SELECT id AS 'id', personal_number AS 'personalNumber',first_name AS 'name', email AS 'email', pass_word AS 'password', landscape.name AS 'landscape' " +
    //                         "FROM user_account INNER JOIN landscape ON user_account.land_scape_id = landscape.id;";
    //         users = connection.Query<User>(query).ToList();
    //         return users;
    //     }
    // }
}
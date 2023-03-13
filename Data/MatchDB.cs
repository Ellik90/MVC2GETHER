using Dapper;
using MySqlConnector;
using MVC2GETHER.Models;
namespace MVC2GETHER.Data;
public class MatchDB 
{
    public int CheckIfMatchesExists(User user, int otherUserId)
    {
        int id = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string? query = "select m.id from matches m " +
                            " WHERE m.one_user_account_id = @userId AND m.two_user_account_id = @otherUserId;";
            id = connection.ExecuteScalar<int>(query, new { @userId = user.Id, @otherUserId = otherUserId });
            return id;
        }
    }

    public List<User> GetMatches(User user)
    {
        List<User> matches = new();
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "SELECT u2.id as 'Id', u2.first_name AS 'Name' " +
                            "FROM matches m INNER JOIN user_account u1 " +
                            "ON m.one_user_account_id = u1.id INNER JOIN user_account u2 " +
                            "ON m.two_user_account_id = u2.id WHERE u1.id = @Id;";
            matches = connection.Query<User>(query, param: user).ToList();
        }
        return matches;
    }

    public void InsertInterestsChoise(User user, int interests)
    {
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO user_interests(interests_id, user_account_id) VALUES (@Interest,@userId);";
            connection.ExecuteScalar<int>(query, new { @Interest = interests, @userId = user.Id });
        }
    }

    public void InsertAgesChoise(User user, int ages)
    {
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO user_age(age_id, user_account_id) VALUES (@Ages,@userId);";
            connection.ExecuteScalar<int>(query, new { @Ages = ages, @userId = user.Id });
        }
    }

    public void InsertLandscapesChoise(User user, int landscapes)
    {
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO user_landscape(landscape_id, user_account_id) VALUES (@Landscapes,@userId);";
            connection.ExecuteScalar<int>(query, new { @Landscapes = landscapes, @userId = user.Id });
        }
    }

    public List<User> GetUsersByLandscapeAndAgeAndInterests(User user) 
    {
        List<User> matchUsers = new();
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = " SELECT u.id, u.first_name, u.last_name FROM user_account u " +
                           " INNER JOIN user_account u2 " +
                           " INNER JOIN user_landscape ul " +
                           " ON ul.user_account_id = u2.id " + 
                           " INNER JOIN user_interests ui2 " +
                           " ON ui2.user_account_id = u2.id " +
                           " INNER JOIN user_interests ui1 " +
                           " ON ui1.user_account_id = u.id " +
                           " INNER JOIN user_age ua " +
                           " ON ua.user_account_id = u2.id " +
                           " INNER JOIN age a " +
                           " ON a.id = ua.age_id " +
                           " WHERE u.land_scape_id = ul.landscape_id " +
                           " AND ui1.interests_id = ui2.interests_id " +
                           " AND u.age >= a.lower_age AND u.age <= a.upper_age " +
                           " AND u2.id = @id " +
                           " AND u.id != @Id GROUP BY u.id; ";
                           
            matchUsers = connection.Query<User>(query, param: user).ToList();
        }
        return matchUsers;
    }
    public void CreateMatch(User user, int id)
    {
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO matches (one_user_account_id,two_user_account_id)" +
                            "VALUES (@userId,@otherUserId); " +
                            "INSERT INTO matches (one_user_account_id,two_user_account_id)" +
                            "VALUES (@otherUserId,@userId); ";
            connection.Query<User>(query, new { @userId = user.Id, @otherUserId = id });
        }
    }

    public void SayYesOrNoToMatch(User user, int id)
    {
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO matches (is_matched_user1,is_matched_user2)" +
                            "VALUES (@userId,@otherUserId); ";
            connection.Query<User>(query, new { @userId = user.Id, @otherUserId = id });
        }
    }
}
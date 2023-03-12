namespace Models;
using Data;

public class MatchService 
{
    MatchDB _matchDB;

    public MatchService(MatchDB matchDB)
    {
        _matchDB = matchDB;
    }

    public void SetMatches(User user)  //denna sätter matchningarna 
    {
        try
        {
            List<User> users = _matchDB.GetUsersByLandscapeAndAgeAndInterests(user);
            List<User> usersToMatches = new();
            foreach (User matches in users)
            {
                int id = _matchDB.CheckIfMatchesExists(user, matches.Id);
                if (id < 1)
                {
                    usersToMatches.Add(matches);
                }
            }
            //DOM SOM EJ ÄR I MATCHES ÄN
            foreach (User u in usersToMatches)
            {
                _matchDB.CreateMatch(user, u.Id);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public List<User> GetMatches(User user)
    {
        List<User> myMatches = new();
        myMatches = _matchDB.GetMatches(user);
        return myMatches;
    }

    // public bool LandscapeMatch(User user)
    // {
    //     int rows = 0;
    //     rows = _matchHandeler.LandscapeMatch(user);
    //     if (rows > 0)
    //     {
    //         return true;
    //     }
    //     else
    //     {
    //         return false;
    //     }
    // }

    // public void SetTheYesAndNO(User user, string word)
    // {
    //     List<User> matches = _matchHandeler.GetUsersByLandscapeAndAge(user);
    //     foreach (User item in matches)
    //     {
    //         _matchHandeler.SayYesOrNoToMatch(user, item.Id);
    //     }
    // }

    public void InsertInterestsChoise(User user, List<int> interests)
    {
        foreach (int item in interests)
        {
            _matchDB.InsertInterestsChoise(user, item);
        }
    }

    public void InsertAgesChoise(User user, List<int> ages)
    {
        foreach (int item in ages)
        {
            _matchDB.InsertAgesChoise(user, item);
        }
    }

    public void InsertLandscapesChoise(User user, List<int> landsScapes)
    {
        foreach (int item in landsScapes)
        {
            _matchDB.InsertLandscapesChoise(user, item);
        }
    }
}
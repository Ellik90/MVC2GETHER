using System.ComponentModel;
namespace MVC2GETHER.Models;


public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string? Gender { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string PersonalNumber {get;set;}
    public string PassWord { get; set; }
    public string AboutMe { get; set; }
    public int LandscapeId{get;set;}

    public User(string name, string lastName, string gender, int age, string email, string personalNumber,string passWord)
    {
        Name = name;
        LastName = lastName;
        Gender = gender;
        Age = age;
        Email = email;
        PersonalNumber = personalNumber;
        PassWord = passWord;
    }
    public User()
    {

    }
    // ta bort enum och hämta ut lanskapen från databasen ist
    public enum Landscapes
    {
        Undefined,
        Norrbotten,
        Västerbotten,
        Jämtland,
        Västernorrland,
        Gävleborg,
        Dalarna,
        Uppsala,
        Västmanland,
        Värmland,
        Stockholm,
        Södermanland,
        Örebro,
        Östergötland,
        [Description("Västra Götaland")]VästraGötaland,
        Jönköping,
        Kalmar,
        Kronoberg,
        Gotland,
        Halland,
        Blekinge,
        Skåne


    }

    public override string ToString()
    {
        return $"[{Id}] {Name} {LastName} <3";
    }

}
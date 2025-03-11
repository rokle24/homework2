using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace homework2;

public class User
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Username {get; set;}
    public string Password {get; set;}
    public bool IsTeacher {get; set;}
    public List<string> Subjects {get; set;}

    public User(string name, string username, string password, bool isTeacher)
    {
        Id = JsonDbUser.LoadUsers().Count+1;
        Name = name;
        Username = username;
        Password = password;
        IsTeacher = isTeacher;
        Subjects = new List<string>();
    }

    [JsonConstructor]
    public User(int id, string name, string username, string password, bool isTeacher, List<string> subjects)
    {
        Id = id;
        Name = name;
        Username = username;
        Password = password;
        IsTeacher = isTeacher;
        Subjects = subjects;
    }
}

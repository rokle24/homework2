using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace homework2;

public class User
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Username {get; set;}
    public string PasswordHash {get; set;}
    public bool IsTeacher {get; set;}
    public byte[] Salt {get; set;}
    public List<Subject> Subjects {get; set;}

    public User(string name, string username, string password, bool isTeacher)
    {
        Id = JsonDbUser.LoadUsers().Count+1;
        Name = name;
        Username = username;
        IsTeacher = isTeacher;
        Subjects = new List<Subject>();
        PasswordSet(password);
    }

    [JsonConstructor]
    public User(int id, string name, string username, string passwordHash, bool isTeacher, 
        List<Subject> subjects, byte[] salt)
    {
        Id = id;
        Name = name;
        Username = username;
        PasswordHash = passwordHash;
        IsTeacher = isTeacher;
        Subjects = subjects;
        Salt = salt;
    }

    public void PasswordSet(string password)
    {
        (string, byte[]) pwd = Hash.HashPasword(password, Salt);
        Salt = pwd.Item2;
        PasswordHash = pwd.Item1;
    }
}

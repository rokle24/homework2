using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace homework2;

public static class JsonDbUser
{
    private static readonly string FilePath = "users.json";
    public static User? CurrentUser { get; set; }
    public static List<User> LoadUsers()
    {
        if (!File.Exists(FilePath)) return new List<User>();
       
        string json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<User>>(json, options) ?? new List<User>();
    }

    private static JsonSerializerOptions options = new JsonSerializerOptions
    {
        IncludeFields = true
    };

    public static void EditSubject(Subject subject)
    {
        List<User> users = LoadUsers();
        users.ForEach(usr =>
        {
            usr.Subjects.ForEach(sbj =>
            {
                if (sbj.Id == subject.Id)
                {
                    sbj.Name = subject.Name;
                    sbj.Description = subject.Description;
                }
            });
        });
        CurrentUser.Subjects.Find(s => s.Id == subject.Id).Description = subject.Description;
        CurrentUser.Subjects.Find(s => s.Id == subject.Id).Name = subject.Name;
        
        SaveUsers(users);
    }
    
    public static void RemoveSubject(Subject subject)
    {
        CurrentUser.Subjects.Remove(subject);
        var users = LoadUsers();

        users.Find(u => u.Username == CurrentUser.Username).Subjects = CurrentUser.Subjects;

        if (CurrentUser.IsTeacher)
        {
            foreach (var user in users)
            {
                user.Subjects.RemoveAll(s => s.Name == subject.Name);
            }
        }
        
        SaveUsers(users);
    }
    
    public static void AddSubject(Subject subject)
    {
        CurrentUser.Subjects.Add(subject);
        var users = LoadUsers();
        users.Find(u => u.Username == CurrentUser.Username).Subjects = CurrentUser.Subjects;
        SaveUsers(users);
    }

    public static void SaveUsers(List<User> users)
    {
        string json = JsonSerializer.Serialize(users);
        File.WriteAllText(FilePath, json);
    }

    public static void AddUser(User user)
    {
        var users = LoadUsers();
        users.Add(user);
        SaveUsers(users);
    }

    public static bool ValidateUser(string username, string password)
    {
        var users = LoadUsers();
        User user;

        if (users.Exists(u => u.Username == username))
        {
            user = users.Find(u => u.Username == username);
            return Hash.VerifyPassword(password, user.PasswordHash, user.Salt);
        }  
        return false;
    }

    public static User GetUser(string username)
    {
        var users = LoadUsers();
        return users.Find(u => u.Username == username);
    }

    public static bool CheckIfUserExists(string username)
    {
        var users = LoadUsers();
        return users.Exists(u => u.Username == username);
    }
}
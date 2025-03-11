using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;

namespace homework2;

public static class JsonDbUser
{
    private static readonly string FilePath = "users.json";
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
    
    public static void SaveUsers(List<User> users)
    {
        string json = JsonSerializer.Serialize(users);
        File.WriteAllText(FilePath, json);
        Console.Write(FilePath);
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
        return users.Exists(u => u.Username == username && u.Password == password);
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
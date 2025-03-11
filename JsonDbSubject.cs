using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace homework2;

public static class JsonDbSubject
{
    private static readonly string FilePath = "subjects.json";
    public static List<Subject> LoadSubjects()
    {
        if (!File.Exists(FilePath)) return new List<Subject>();
       
        string json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<Subject>>(json, options) ?? new List<Subject>();
    }

    private static JsonSerializerOptions options = new JsonSerializerOptions
    {
        IncludeFields = true
    };
    
    public static void SaveSubjects(List<Subject> subjects)
    {
        string json = JsonSerializer.Serialize(subjects);
        File.WriteAllText(FilePath, json);
        Console.Write(FilePath);
    }

    public static void AddSubject(Subject subject)
    {
        var subjects = LoadSubjects();
        subjects.Add(subject);
        SaveSubjects(subjects);
    }

    public static string[] GetSubjects()
    {
        var subjects = LoadSubjects();
        return subjects.ConvertAll(s => s.Name).ToArray();
    }
    
    public static Subject GetSubject(string subjectName)
    {
        var subjects = LoadSubjects();
        return subjects.Find(s => s.Name == subjectName);
    }

    public static void RemoveSubject(string subjectName)
    {
        var subjects = LoadSubjects();
        subjects.Remove(subjects.Find(s => s.Name == subjectName));
        SaveSubjects(subjects);
    }
    
}
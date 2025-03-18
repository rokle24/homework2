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

    public static void AddStudent(Subject subject, string studentName)
    {
       var subjects = LoadSubjects();
       subjects.Find(x => x.Name == subject.Name).StudentsEnrolled.Add(studentName);
       SaveSubjects(subjects);
       
    }

    public static void RemoveStudent(Subject subject, string studentName)
    {
        var subjects = LoadSubjects();
        subjects.Find(x => subject.Name == x.Name).StudentsEnrolled.Remove(studentName);
        SaveSubjects(subjects);
    }
    
    public static void SaveSubjects(List<Subject> subjects)
    {
        string json = JsonSerializer.Serialize(subjects);
        File.WriteAllText(FilePath, json);
    }

    public static void AddSubject(Subject subject)
    {
        var subjects = LoadSubjects();
        subjects.Add(subject);
        SaveSubjects(subjects);
    }

    public static void RemoveSubject(Subject subject)
    {
        var subjects = LoadSubjects();
        subjects.Remove(subjects.Find(s => s.Name == subject.Name));
        SaveSubjects(subjects);
    }

    public static Subject[] GetSubjects()
    {
        return LoadSubjects().ToArray();
    }

    public static string GetStudentsEnrolled(string subjectName)
    {
        return LoadSubjects().Find(x => x.Name == subjectName).GetStudentsEnrolled();
    }

    public static bool SubjectExists(string subjectName)
    {
        return LoadSubjects().Find(x => x.Name == subjectName) != null;
    }

    public static void EditSubject(Subject subject)
    {
        List<Subject> subjects = LoadSubjects();
        subjects.Find(x => x.Id == subject.Id).Name = subject.Name;
        subjects.Find(x => x.Id == subject.Id).Description = subject.Description;
        SaveSubjects(subjects);
    }

    public static int GenerateId()
    {
        int id = 1;
        foreach (var subject in LoadSubjects())
        {
            if (subject.Id >= id)
            {
                id = subject.Id+1;
            }
        }
        return id;
    }
}
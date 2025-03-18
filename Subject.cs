using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace homework2;

public class Subject
{
    
    public string Name {get; set;}
    public string Description {get; set;}
    public string TeacherName {get; set;}
    public int Id {get; set;}
    
    public List<string> StudentsEnrolled {get; set;}
    public string Tooltip => $"{TeacherName} \n \n {Description}";

    public Subject(string name, string description, string teacherName)
    {
        Name = name;
        Description = description;
        TeacherName = teacherName;
        StudentsEnrolled = new List<string>();
        Id = JsonDbSubject.GenerateId();
    }
    
    
    [JsonConstructor]
    public Subject(string name, string description, string teacherName, List<string> studentsEnrolled, int id)
    {
        Name = name;
        Description = description;
        TeacherName = teacherName;
        StudentsEnrolled = studentsEnrolled;
        Id = id;
    }

    public string GetStudentsEnrolled()
    {
        return StudentsEnrolled.Count == 0? "No students enrolled" : string.Join(", ", StudentsEnrolled);
    }
}
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace homework2;

public class Subject
{
    
    public string Name {get; set;}
    public string Description {get; set;}
    public string TeacherName {get; set;}
    public List<int> StudentsEnrolled;

    public Subject(string name, string description, string teacherName)
    {
        Name = name;
        Description = description;
        TeacherName = teacherName;
        StudentsEnrolled = new List<int>();
    }

    [JsonConstructor]
    public Subject(string name, string description, string teacherName, List<int> studentsEnrolled)
    {
        Name = name;
        Description = description;
        TeacherName = teacherName;
        StudentsEnrolled = studentsEnrolled;
    }
    

    public void addStudentEnrolled(int studentId) => StudentsEnrolled.Add(studentId);

    public void removeStudentEnrolled(int studentId) => StudentsEnrolled.Remove(studentId);
}
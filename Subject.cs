using System.Collections.Generic;

namespace homework2;

public class Subject
{
    private int id;
    private string name;
    private string description;
    private int teacherId;
    private List<int> studentsEnrolled;

    public Subject(int id, string name, string description, int teacherId)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.teacherId = teacherId;
        studentsEnrolled = new List<int>();
    }

    public string getSubjectName() => name;
    
    public string getDescription() => description;

    public void setDescription(string newDescription) => description = newDescription;

    public List<int> getStudentsEnrolled() => studentsEnrolled;

    public void addStudentEnrolled(int studentId) => studentsEnrolled.Add(studentId);

    public void removeStudentEnrolled(int studentId) => studentsEnrolled.Remove(studentId);
}
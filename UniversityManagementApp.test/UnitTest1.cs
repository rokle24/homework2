using System;
using System.Collections.Generic;
using Xunit;
using System.IO;
using System.Text.Json;
using System.Linq;
using homework2;

namespace UniversityManagementApp.test;

public class UniversityManagementTests
{
    [Fact]
    public void StudentEnrollmentTest()
    {
        var student = new User("Diego", "diego123", "password123", false);
        var subject = new Subject("Advanced Object-Oriented Programming", "Learn unit testing", "Maximilian von Zastrow");
        
        student.Subjects.Add(subject);
        subject.StudentsEnrolled.Add(student.Name);
        
        Assert.Contains(subject, student.Subjects);
        Assert.Contains(student.Name, subject.StudentsEnrolled);
    }

    [Fact]
    public void DropSubjectTest()
    {
        var student = new User("Diego", "diego123", "password123", false);
        var subject = new Subject("Advanced Object-Oriented Programming", "Learn unit testing", "Maximilian von Zastrow");
        
        student.Subjects.Add(subject);
        subject.StudentsEnrolled.Add(student.Name);

        Assert.Contains(subject, student.Subjects);
        Assert.Contains(student.Name, subject.StudentsEnrolled);
        
        student.Subjects.Remove(subject);
        subject.StudentsEnrolled.Remove(student.Name);
        
        Assert.DoesNotContain(subject, student.Subjects);
        Assert.DoesNotContain(student.Name, subject.StudentsEnrolled);
    }
    
    [Fact]
    public void CreateSubjectTest()
    {
        var teacher = new User("Adam Alami", "Adam456", "password456", true);
        var subject = new Subject("Software Engineering", "Agile development", teacher.Name);

        teacher.Subjects.Add(subject);
        var allSubjects = new List<Subject>();
        allSubjects.Add(subject);
        
        Assert.Contains(subject, teacher.Subjects);
        Assert.Contains(subject, allSubjects);
        Assert.Equal(teacher.Name, subject.TeacherName);
    }

        [Fact]
    public void DeleteSubjectTest()
    {
        var teacher = new User("Adam Alami", "Adam456", "password456", true);
        var subject = new Subject("Software Engineering", "Agile development", teacher.Name);
        
        teacher.Subjects.Add(subject);
        var allSubjects = new List<Subject>();
        allSubjects.Add(subject);
        
        Assert.Contains(subject, teacher.Subjects);
        Assert.Contains(subject, allSubjects);

        teacher.Subjects.Remove(subject);
        allSubjects.Remove(subject);
        
        Assert.DoesNotContain(subject, teacher.Subjects);
        Assert.DoesNotContain(subject, allSubjects);
    }
    
    [Fact]
    public void LoginValidationTest()
    {
        var student = new User("Diego", "diego123", "password123", false);
        var teacher = new User("Adam Alami", "Adam456", "password456", true);
        
        var users = new List<User> { student, teacher };
        
        var foundStudent = users.FirstOrDefault(u => u.Username == "diego123");
        Assert.NotNull(foundStudent);
        Assert.Equal("Diego", foundStudent.Name);
        Assert.False(foundStudent.IsTeacher);
        
        var foundTeacher = users.FirstOrDefault(u => u.Username == "Adam456");
        Assert.NotNull(foundTeacher);
        Assert.Equal("Adam Alami", foundTeacher.Name);
        Assert.True(foundTeacher.IsTeacher);
        
        var nonExistentUser = users.FirstOrDefault(u => u.Username == "notauser");
        Assert.Null(nonExistentUser);
        
        Assert.False(student.IsTeacher, "Student should not have teacher role");
        Assert.True(teacher.IsTeacher, "Teacher should have teacher role");
    }
    
    [Fact]
    public void DataPersistenceTest()
    {
        var testSubject = new Subject("Test Subject", "This is a test subject", "Test Teacher");
        var testSubjects = new List<Subject> { testSubject };
        
        string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempDir);
        string tempSubjectFile = Path.Combine(tempDir, "subjects.json");
        
        try
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            
            string subjectJson = JsonSerializer.Serialize(testSubjects, options);
            File.WriteAllText(tempSubjectFile, subjectJson);
            
            string loadedSubjectJson = File.ReadAllText(tempSubjectFile);
            var loadedSubjects = JsonSerializer.Deserialize<List<Subject>>(loadedSubjectJson, options);
            
            Assert.NotNull(loadedSubjects);
            Assert.Single(loadedSubjects);
            
            var loadedSubject = loadedSubjects[0];
            
            Assert.Equal(testSubject.Name, loadedSubject.Name);
            Assert.Equal(testSubject.Description, loadedSubject.Description);
            Assert.Equal(testSubject.TeacherName, loadedSubject.TeacherName);
            Assert.Equal(testSubject.Id, loadedSubject.Id);
            
            Assert.Empty(loadedSubject.StudentsEnrolled);
            
            loadedSubject.StudentsEnrolled.Add("Test Student");
            
            subjectJson = JsonSerializer.Serialize(loadedSubjects, options);
            File.WriteAllText(tempSubjectFile, subjectJson);
            
            loadedSubjectJson = File.ReadAllText(tempSubjectFile);
            var updatedSubjects = JsonSerializer.Deserialize<List<Subject>>(loadedSubjectJson, options);
            
            Assert.NotNull(updatedSubjects);
            Assert.Single(updatedSubjects);
            Assert.Single(updatedSubjects[0].StudentsEnrolled);
            Assert.Equal("Test Student", updatedSubjects[0].StudentsEnrolled[0]);
        }
        finally
        {
            try
            {
                if (Directory.Exists(tempDir))
                {
                    Directory.Delete(tempDir, true);
                }
            }
            catch (IOException)
            {
                // Ignore cleanup errors
            }
        }
    }
}

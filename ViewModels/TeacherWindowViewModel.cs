using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;

namespace homework2.ViewModels;

public class TeacherWindowViewModel : ViewModelBase
{
    public ObservableCollection<Subject> MySubjects { get; set; } 
    private Subject _selectedSubject;
    private string _textBoxContent = "Hover over subject to see description";
    private string _textBox2Content = "Select subject to see students enrolled";
    
    
    public TeacherWindowViewModel()
    {
        MySubjects = new ObservableCollection<Subject>(JsonDbUser.CurrentUser.Subjects);
    }

    public void UpdateSubjects()
    {
        MySubjects.Clear(); 

        foreach (var subject in JsonDbUser.CurrentUser.Subjects)
        {
            MySubjects.Add(subject); 
        }
        
    }
    public Subject SelectedSubject
    {
        get => _selectedSubject;
        set
        {
            _selectedSubject = value;
            OnPropertyChanged();
            UpdateTextBoxContent(); 
        }
    }

    public string TextBoxContent
    {
        get => _textBoxContent;
        set
        {
            _textBoxContent = value;
            OnPropertyChanged();
            
        }
    }
    
    public string TextBox2Content
    {
        get => _textBox2Content;
        set
        {
            _textBox2Content = value;
            OnPropertyChanged();
            
        }
    }
    
    
    public void UpdateTextBoxContent()
    {
        TextBoxContent = JsonDbSubject.GetStudentsEnrolled(_selectedSubject.Name);
        TextBox2Content = "";
    }
}



using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Threading;

namespace homework2.ViewModels;

public class StudentWindowViewModel : ViewModelBase
{
    public ObservableCollection<Subject> Subjects { get; set; } 
    public ObservableCollection<Subject> MySubjects { get; set; } 
    
    public StudentWindowViewModel()
    {
        MySubjects = new ObservableCollection<Subject>(JsonDbUser.CurrentUser.Subjects);
        Subjects = new ObservableCollection<Subject>(JsonDbSubject.GetSubjects());
    }
    
    public void UpdateSubjects()
    {
        MySubjects.Clear(); 

        foreach (var subject in JsonDbUser.CurrentUser.Subjects)
        {
            MySubjects.Add(subject); 
        }
        
    }
}
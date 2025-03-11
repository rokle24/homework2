using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace homework2.ViewModels;

public class TeacherWindowViewModel : ViewModelBase
{
    public ObservableCollection<string> MySubjects { get; set; } 
    private List<string> _mySubjects;
    
    public TeacherWindowViewModel()
    {
        MySubjects = new ObservableCollection<string>(JsonDbUser.CurrentUser.Subjects.ToList());
        
    }
    
    public List<string> Mysubjects
    {
        get { return _mySubjects; }
        set
        {
            _mySubjects = value;
            OnPropertyChanged(nameof(MySubjects));
        }
    }
    
}
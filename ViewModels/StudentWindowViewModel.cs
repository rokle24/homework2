using System.Collections.ObjectModel;
using System.Linq;

namespace homework2.ViewModels;

public class StudentWindowViewModel : ViewModelBase
{
    public ObservableCollection<string> Subjects { get; set; } 
    public ObservableCollection<string> MySubjects { get; set; } 
    
    public StudentWindowViewModel()
    {
        MySubjects = new ObservableCollection<string>(JsonDbUser.CurrentUser.Subjects.ToList());
        Subjects = new ObservableCollection<string>(JsonDbSubject.GetSubjects().ToList());
    }
}
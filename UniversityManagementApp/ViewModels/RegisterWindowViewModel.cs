using System.Collections.ObjectModel;

namespace homework2.ViewModels;

public class RegisterWindowViewModel : ViewModelBase
{
    private string _selection;

    public RegisterWindowViewModel()
    {
        selection = SelectionList[0];
    }

    public ObservableCollection<string> SelectionList { get;} = new()
    {
        "Student", "Teacher"
    };
    
    public string selection
    {
        get { return _selection; }
        set
        {
            _selection = value;
            OnPropertyChanged(nameof(SelectionList));
        }
    }
}
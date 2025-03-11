using System.ComponentModel;
using homework2.Views;


namespace homework2.ViewModels;


public partial class MainWindowViewModel : ViewModelBase , INotifyPropertyChanged
{
    
    private ViewModelBase _currentPage;
    public event PropertyChangedEventHandler? PropertyChanged;
    
    
    public MainWindowViewModel()
    {
        _currentPage = Windows[0];
        WindowManager.RegisterWindow += () => RegisterWindow();
        WindowManager.LoginWindow += () => LoginWindow();
        WindowManager.StudentWindow += () => AppWindow();
        WindowManager.TeacherWindow += () => TeacherWindow();
    }
    
    
    public ViewModelBase CurrentPage
    {
        get {return _currentPage; }
    }

    private ViewModelBase[] Windows =
    {
        new LoginWindowViewModel(),
        new RegisterWindowViewModel(),
        new StudentWindowViewModel(),
        new TeacherWindowViewModel()
    };

    public System.Action RegisterWindow()
    {
        _currentPage = Windows[1];
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPage)));
        return null;
    }

    public System.Action LoginWindow()
    {
        _currentPage = Windows[0];
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPage)));
        return null;
    }

    public System.Action AppWindow()
    {
        _currentPage = Windows[2];
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPage)));
        return null;
    }

    public System.Action TeacherWindow()
    {
        _currentPage = Windows[3];
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPage)));
        return null;
    }
    
    
    
    
}


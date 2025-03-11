
using Avalonia.Controls;
using Avalonia.Interactivity;


namespace homework2.Views;

public partial class LoginWindowView : UserControl
{
    
    public LoginWindowView()
    {
        InitializeComponent();
        RegisterButton.Click += RegisterButton_OnClick;
        LoginButton.Click += LoginButton_OnClick;
        
    }
    
    private void RegisterButton_OnClick(object? sender, RoutedEventArgs e)
    {
        WindowManager.TriggerRegWindow();
    }

    private void LoginButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (JsonDbUser.ValidateUser(UserNameBox.Text, PasswordBox.Text))
        {
            MainWindow.User = JsonDbUser.GetUser(UserNameBox.Text);
            if (MainWindow.User.IsTeacher) WindowManager.TriggerTeacherWindow();
            else WindowManager.TriggerStudentWindow();
            
            
        } else Msg.Text = "Wrong username or password";
    }
}
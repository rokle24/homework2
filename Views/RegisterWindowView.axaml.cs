using Avalonia.Controls;
using Avalonia.Interactivity;

namespace homework2.Views;

public partial class RegisterWindowView : UserControl
{
    
    public RegisterWindowView()
    {
        InitializeComponent();
        RegisterButton.Click += RegisterButtonOnClick;
        ReturnButton.Click += ReturnButtonOnClick;
    }

    private void ReturnButtonOnClick(object? sender, RoutedEventArgs e)
    {
        WindowManager.TriggerLogWindow();
    }

    private void RegisterButtonOnClick(object? sender, RoutedEventArgs e)
    {
        string? name = FullNameBox.Text;
        string? username = UserNameBox.Text;
        string? password = PasswordBox.Text;
        string? selection = ListBox.SelectedItem.ToString();

        if (string.IsNullOrWhiteSpace(name) 
            || string.IsNullOrWhiteSpace(username) 
            || string.IsNullOrWhiteSpace(password) 
            || string.IsNullOrWhiteSpace(selection))
        {
            RegForm.Text = "Fill all fields";
        }
        else if(JsonDbUser.CheckIfUserExists(username) ) RegForm.Text = "User already exists!";
        else
        {
            JsonDbUser.AddUser(new User(name, username, password, selection == "Teacher"));
            WindowManager.TriggerLogWindow();
        }
    }
}
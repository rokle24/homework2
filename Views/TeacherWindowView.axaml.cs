using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace homework2.Views;

public partial class TeacherWindowView : UserControl
{
    public TeacherWindowView()
    {
        InitializeComponent();
        AddSubjectButton.Click += AddSubjectButtonOnClick;
        RemoveSubjectButton.Click += RemoveSubjectButtonOnClick;
    }
    
    private void RemoveSubjectButtonOnClick(object? sender, RoutedEventArgs e)
    {
        JsonDbUser.RemoveSubject(MySubjectComboBox.SelectedItem.ToString());
        JsonDbSubject
    }

    private void AddSubjectButtonOnClick(object? sender, RoutedEventArgs e)
    {
        string name = AddSubjectTextBox.Text;
        string descr = AddDescriptionTextBox.Text;
        Subject subject = new Subject(name, descr, JsonDbUser.CurrentUser.Name);
        JsonDbSubject.AddSubject(subject);
        JsonDbUser.AddSubject(name);
        
    }
}
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
        EditSubjectButton.Click += EditSubjectButtonOnClick;
        LogOutButton.Click += LogOutButtonOnClick;
    }

    private void LogOutButtonOnClick(object? sender, RoutedEventArgs e)
    {
        JsonDbUser.CurrentUser = null;
        WindowManager.TriggerLogWindow();
    }

    private void EditSubjectButtonOnClick(object? sender, RoutedEventArgs e)
    {
        if (MySubjectComboBox.SelectedItem != null)
        {
            Subject subject = (Subject)MySubjectComboBox.SelectedItem;
            AddSubjectTextBox.Text = subject.Name;
            AddDescriptionTextBox.Text = subject.Description;
            JsonDbUser.RemoveSubject((Subject)MySubjectComboBox.SelectedItem);
            JsonDbSubject.RemoveSubject((Subject)MySubjectComboBox.SelectedItem);
        } 
    }

    private void RemoveSubjectButtonOnClick(object? sender, RoutedEventArgs e)
    {
        if (MySubjectComboBox.SelectedItem != null)
        {
            JsonDbUser.RemoveSubject((Subject)MySubjectComboBox.SelectedItem);
            JsonDbSubject.RemoveSubject((Subject)MySubjectComboBox.SelectedItem);
        }
    }

    private void AddSubjectButtonOnClick(object? sender, RoutedEventArgs e)
    {
        string name = AddSubjectTextBox.Text;
        string descr = AddDescriptionTextBox.Text;
        Subject subject = new Subject(name, descr, JsonDbUser.CurrentUser.Name);
        JsonDbSubject.AddSubject(subject);
        JsonDbUser.AddSubject(subject);
        AddSubjectTextBox.Clear();
        AddDescriptionTextBox.Clear();
    }
}
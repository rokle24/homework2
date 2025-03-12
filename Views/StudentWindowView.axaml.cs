using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace homework2.Views;

public partial class StudentWindowView : UserControl
{
    public StudentWindowView()
    {
        InitializeComponent();
        AddSubjectButton.Click += AddSubjectButtonOnClick;
        RemoveSubjectButton.Click += RemoveSubjectButtonOnClick;
        LogOutButton.Click += LogOutButtonOnClick;
    }

    private void LogOutButtonOnClick(object? sender, RoutedEventArgs e)
    {
        JsonDbUser.CurrentUser = null;
        WindowManager.TriggerLogWindow();
    }

    private void RemoveSubjectButtonOnClick(object? sender, RoutedEventArgs e)
    {
        if (MySubjectComboBox.SelectedItem != null)
        {
            JsonDbUser.RemoveSubject((Subject)MySubjectComboBox.SelectedItem);
            JsonDbSubject.RemoveStudent((Subject)MySubjectComboBox.SelectedItem, JsonDbUser.CurrentUser.Name);
        }
    }
    private void AddSubjectButtonOnClick(object? sender, RoutedEventArgs e)
    {
        if (SubjectComboBox.SelectedItem != null)
        {
            Subject subject = (Subject)SubjectComboBox.SelectedItem;
            JsonDbUser.AddSubject(subject);
            JsonDbSubject.AddStudent(subject, JsonDbUser.CurrentUser.Name);
        }
        
    }
}
using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;

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
            PopUpRemove();
        }
    }
    private void AddSubjectButtonOnClick(object? sender, RoutedEventArgs e)
    {
        if (SubjectComboBox.SelectedItem != null)
        {
            Subject subject = (Subject)SubjectComboBox.SelectedItem;

            if (JsonDbUser.CurrentUser.Subjects.Find(s => s.Name == subject.Name) == null)
            {
                JsonDbUser.AddSubject(subject);
                JsonDbSubject.AddStudent(subject, JsonDbUser.CurrentUser.Name);
                PopUpAdd(); 
            }
            else
            {
                PopUpAlreadyAdded();
            }
        }
    }
    
    private void PopUpAlreadyAdded()
    {
        PopupAlreadyAdded.IsOpen = true;
        DispatcherTimer timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(2)
        };
        timer.Tick += (s, args) =>
        {
            PopupAlreadyAdded.IsOpen = false;
            timer.Stop(); 
        };
        timer.Start();
    }
    
    private void PopUpAdd()
    {
        PopupSubjectAdded.IsOpen = true;
        DispatcherTimer timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(2)
        };
        timer.Tick += (s, args) =>
        {
            PopupSubjectAdded.IsOpen = false;
            timer.Stop(); 
        };
        timer.Start();
    }
    
    private void PopUpRemove()
    {
        PopupSubjectRemoved.IsOpen = true;
        DispatcherTimer timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(2)
        };
        timer.Tick += (s, args) =>
        {
            PopupSubjectRemoved.IsOpen = false;
            timer.Stop(); 
        };
        timer.Start();
    }
    
}
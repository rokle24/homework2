using System;
using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using homework2.ViewModels;

namespace homework2.Views;

public partial class TeacherWindowView : UserControl
{
    private readonly TeacherWindowViewModel _teacherWindowViewModel;
    private Subject _subjectEditing;
    private bool _isEditing = false;
    
    public TeacherWindowView()
    {
        InitializeComponent();
        AddSubjectButton.Click += AddSubjectButtonOnClick;
        RemoveSubjectButton.Click += RemoveSubjectButtonOnClick;
        EditSubjectButton.Click += EditSubjectButtonOnClick;
        LogOutButton.Click += LogOutButtonOnClick;
        _teacherWindowViewModel = new TeacherWindowViewModel();
        DataContext = _teacherWindowViewModel;
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
            _subjectEditing = subject;
            _isEditing = true;
            EditingSubjectText(subject.Name);
        } 
    }

    private void RemoveSubjectButtonOnClick(object? sender, RoutedEventArgs e)
    {
        if (MySubjectComboBox.SelectedItem != null)
        {
            JsonDbUser.RemoveSubject((Subject)MySubjectComboBox.SelectedItem);
            JsonDbSubject.RemoveSubject((Subject)MySubjectComboBox.SelectedItem);
            PopUpRemove();
            ChangeTextBack();
        }
    }

    private void AddSubjectButtonOnClick(object? sender, RoutedEventArgs e)
    {
        string name = AddSubjectTextBox.Text;
        string descr = AddDescriptionTextBox.Text;

        if (_isEditing)
        {
            _subjectEditing.Name = AddSubjectTextBox.Text;
            _subjectEditing.Description = AddDescriptionTextBox.Text;
            JsonDbSubject.EditSubject(_subjectEditing);
            JsonDbUser.EditSubject(_subjectEditing);
            _isEditing = false;
            PopUpAdd();
            AddSubjectTextBox.Clear();
            AddDescriptionTextBox.Clear();
            AddSubjectButton.Content = "Add subject";
            ChangeTextBack();
            
        } else if (!JsonDbSubject.SubjectExists(name))
        {
            Subject subject = new Subject(name, descr, JsonDbUser.CurrentUser.Name);
            JsonDbSubject.AddSubject(subject);
            JsonDbUser.AddSubject(subject);
            AddSubjectTextBox.Clear();
            AddDescriptionTextBox.Clear();
            PopUpAdd();
            ChangeTextBack();
        }
        else
        {
            PopUpExists();
        }
        
    }

    private void ChangeTextBack()
    {
        _teacherWindowViewModel.TextBoxContent = "Hover over subject to see description";
        _teacherWindowViewModel.TextBox2Content = "Select subject to see students enrolled";
    }

    private void EditingSubjectText(string name)
    {
        _teacherWindowViewModel.TextBoxContent = $"Editing subject: {name}";
        _teacherWindowViewModel.TextBox2Content = " ";
        AddSubjectButton.Content = "Edit subject";
    }

    private void PopUpExists()
    {
        PopupExists.IsOpen = true;
        DispatcherTimer timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(2)
        };
        timer.Tick += (s, args) =>
        {
            PopupExists.IsOpen = false;
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
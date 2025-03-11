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
    }

    private void RemoveSubjectButtonOnClick(object? sender, RoutedEventArgs e)
    {
        JsonDbUser.RemoveSubject(MySubjectComboBox.SelectedItem.ToString());
    }

    private void AddSubjectButtonOnClick(object? sender, RoutedEventArgs e)
    {
        JsonDbUser.AddSubject(SubjectComboBox.SelectedItem.ToString());
    }
}
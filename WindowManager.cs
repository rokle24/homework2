using System;

namespace homework2;

public static class WindowManager
{
    public static event Action? RegisterWindow;
    public static event Action? LoginWindow;
    public static event Action? StudentWindow;
    public static event Action? TeacherWindow;
    public static User? User;

    public static void TriggerTeacherWindow()
    {
        TeacherWindow?.Invoke();
    }
    public static void TriggerStudentWindow()
    {
        StudentWindow?.Invoke();
    }
    
    public static void TriggerRegWindow()
    {
        RegisterWindow?.Invoke();
    }

    public static void TriggerLogWindow()
    {
        LoginWindow?.Invoke();
    }
    
    
}

using UnityEngine;
using KamaliDebug;

public static class write
{

    static bool writing = false;
    static bool writingWarning = false;
    static bool writingError = false;
    static bool writingRed = false;
    static bool writingYellow = false;
    static bool writingGreen = false;
    static bool writingBlue = false;
    static bool writingCyan = false;
    static bool writingMagenta = false;
    static bool writingOrange = false;
    static bool writingOlive = false;
    static bool writingPurple = false;
    static bool writingGray = false;


    static void GetReady()
    {
#if UNITY_EDITOR
        if (WritingWindow.writing) writing = true;
        if (WritingWindow.writingWarning) writingWarning = true;
        if (WritingWindow.writingError) writingError = true;
        if (WritingWindow.writingRed) writingRed = true;
        if (WritingWindow.writingGreen) writingGreen = true;
        if (WritingWindow.writingBlue) writingBlue = true;
        if (WritingWindow.writingCyan) writingCyan = true;
        if (WritingWindow.writingMagenta) writingMagenta = true;
        if (WritingWindow.writingOrange) writingOrange = true;
        if (WritingWindow.writingOlive) writingOlive = true;
        if (WritingWindow.writingPurple) writingPurple = true;
        if (WritingWindow.writingGray) writingGray = true;
#endif
    }


    public static void print(string target)
    {
        GetReady();
        if (writing) Debug.Log(target);
    }
    public static void warning(string target)
    {
        GetReady();
        if (writingWarning) Debug.LogWarning(target);
    }

    public static void error(string target)
    {
        GetReady();
        if (writingError) Debug.LogError(target);
    }

    //

    public static void r(string red)
    {
        GetReady();
        if (writingRed) DebugX.Log($"{red}:red:b;");
    }

    public static void y(string yellow)
    {
        GetReady();
        if (writingYellow) DebugX.Log($"{yellow}:yellow:b;");
    }

    public static void g(string green)
    {
        GetReady();
        if (writingGreen) DebugX.Log($"{green}:green:b;");
    }

    public static void b(string blue)
    {
        GetReady();
        if (writingBlue) DebugX.Log($"{blue}:blue:b;");
    }

    public static void c(string cyan)
    {
        GetReady();
        if (writingCyan) DebugX.Log($"{cyan}:cyan:b;");
    }

    public static void m(string magenta)
    {
        GetReady();
        if (writingMagenta) DebugX.Log($"{magenta}:magenta:b;");
    }

    public static void or(string orange)
    {
        GetReady();
        if (writingOrange) DebugX.Log($"{orange}:orange:b;");
    }

    public static void ol(string olive)
    {
        GetReady();
        if (writingOlive) DebugX.Log($"{olive}:olive:b;");
    }
    public static void p(string purple)
    {
        GetReady();
        if (writingPurple) DebugX.Log($"{purple}:purple:b;");
    }

    public static void gr(string gray)
    {
        GetReady();
        if (writingGray) DebugX.Log($"{gray}:gray:b;");
    }
    
}



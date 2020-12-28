
using UnityEngine;
using UnityEditor;
using KamaliDebug;

public static class write
{

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
        if (WritingWindow.writingRed) writingRed = true;
        if (WritingWindow.writingGreen) writingGreen = true;
        if (WritingWindow.writingBlue) writingBlue = true;
        if (WritingWindow.writingCyan) writingCyan = true;
        if (WritingWindow.writingMagenta) writingMagenta = true;
        if (WritingWindow.writingOrange) writingOrange = true;
        if (WritingWindow.writingOlive) writingOlive = true;
        if (WritingWindow.writingPurple) writingPurple = true;
        if (WritingWindow.writingGray) writingGray = true;
    }


    public static void r(string red)
    {
#if UNITY_EDITOR

        GetReady();

        if (writingRed)
        {
            if (EditorGUIUtility.isProSkin)
            {
                DebugX.Log($"{red}:red:b;");
            }
            else
            {
                DebugX.Log($"{red}:theme_l_red:b;");
            }
        }
#endif
    }

    public static void y(string yellow)
    {
#if UNITY_EDITOR

        GetReady();

        if (writingRed)
        {
            if (EditorGUIUtility.isProSkin)
            {
                DebugX.Log($"{yellow}:yellow:b;");
            }
            else
            {
                DebugX.Log($"{yellow}:theme_l_yellow:b;");
            }
        }
#endif
    }

    public static void g(string green)
    {
#if UNITY_EDITOR

        GetReady();

        if (writingRed)
        {
            if (EditorGUIUtility.isProSkin)
            {
                DebugX.Log($"{green}:green:b;");
            }
            else
            {
                DebugX.Log($"{green}:theme_l_green:b;");
            }
        }
#endif
    }

    public static void b(string blue)
    {
#if UNITY_EDITOR

        GetReady();

        if (writingRed)
        {
            if (EditorGUIUtility.isProSkin)
            {
                DebugX.Log($"{blue}:blue:b;");
            }
            else
            {
                DebugX.Log($"{blue}:theme_l_blue:b;");
            }
        }
#endif
    }

    public static void c(string cyan)
    {
#if UNITY_EDITOR

        GetReady();

        if (writingRed)
        {
            if (EditorGUIUtility.isProSkin)
            {
                DebugX.Log($"{cyan}:cyan:b;");
            }
            else
            {
                DebugX.Log($"{cyan}:theme_l_cyan:b;");
            }
        }
#endif
    }

    public static void m(string magenta)
    {
#if UNITY_EDITOR

        GetReady();

        if (writingRed)
        {
            if (EditorGUIUtility.isProSkin)
            {
                DebugX.Log($"{magenta}:magenta:b;");
            }
            else
            {
                DebugX.Log($"{magenta}:theme_l_magenta:b;");
            }
        }
#endif
    }

    public static void or(string orange)
    {
#if UNITY_EDITOR

        GetReady();

        if (writingRed)
        {
            if (EditorGUIUtility.isProSkin)
            {
                DebugX.Log($"{orange}:orange:b;");
            }
            else
            {
                DebugX.Log($"{orange}:theme_l_orange:b;");
            }
        }
#endif
    }

    public static void ol(string olive)
    {
#if UNITY_EDITOR

        GetReady();

        if (writingRed)
        {
            if (EditorGUIUtility.isProSkin)
            {
                DebugX.Log($"{olive}:olive:b;");
            }
            else
            {
                DebugX.Log($"{olive}:theme_l_olive:b;");
            }
        }
#endif
    }
    public static void p(string purple)
    {
#if UNITY_EDITOR

        GetReady();

        if (writingRed)
        {
            if (EditorGUIUtility.isProSkin)
            {
                DebugX.Log($"{purple}:purple:b;");
            }
            else
            {
                DebugX.Log($"{purple}:theme_l_purple:b;");
            }
        }
#endif
    }

    public static void gr(string gray)
    {
#if UNITY_EDITOR

        GetReady();

        if (writingRed)
        {
            if (EditorGUIUtility.isProSkin)
            {
                DebugX.Log($"{gray}:gray:b;");
            }
            else
            {
                DebugX.Log($"{gray}:theme_l_gray:b;");
            }
        }
#endif
    }
    
}



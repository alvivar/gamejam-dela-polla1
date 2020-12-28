using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR

public class WritingWindow : EditorWindow
{

    public static bool writing = true;
    public static bool writingWarning = true;
    public static bool writingError = true;
    public static bool writingRed = true;
    public static bool writingYellow = true;
    public static bool writingGreen = true;
    public static bool writingBlue = true;
    public static bool writingCyan = true;
    public static bool writingMagenta = true;
    public static bool writingOrange = true;
    public static bool writingOlive = true;
    public static bool writingPurple = true;
    public static bool writingGray = true;

    [MenuItem("Window/Writing Menu")]
    public static void ShowWindow()
    {
        GetWindow<WritingWindow>("Writing Menu");

        GUILayout.Width(120);
        GUILayout.Height(60);
        GUILayout.ExpandHeight(false);
        GUILayout.ExpandWidth(false);

    }

    //

    void OnGUI()
    {

        GUILayout.Width(120);
        GUILayout.Height(60);

        GUILayout.Label("Do you want your prints to show?");

        writing = EditorGUILayout.Toggle("Writing Print", writing);
        writingWarning = EditorGUILayout.Toggle("Writing Warning", writingWarning);
        writingError = EditorGUILayout.Toggle("Writing Error", writingError);
        writingRed = EditorGUILayout.Toggle("Writing Red", writingRed);
        writingYellow = EditorGUILayout.Toggle("Writing Yellow", writingYellow);
        writingGreen = EditorGUILayout.Toggle("Writing Green", writingGreen);
        writingBlue = EditorGUILayout.Toggle("Writing Blue", writingBlue);
        writingCyan = EditorGUILayout.Toggle("Writing Cyan", writingCyan);
        writingMagenta = EditorGUILayout.Toggle("Writing Magenta", writingMagenta);
        writingOrange = EditorGUILayout.Toggle("Writing Orange", writingOrange);
        writingOlive = EditorGUILayout.Toggle("Writing Olive", writingOlive);
        writingPurple = EditorGUILayout.Toggle("Writing Purple", writingPurple);
        writingGray = EditorGUILayout.Toggle("Writing Gray", writingGray);


        EditorPrefs.SetBool("writing", writing);
        EditorPrefs.SetBool("writingWarning", writingWarning);
        EditorPrefs.SetBool("writingError", writingError);
        EditorPrefs.SetBool("writingRed", writingRed);
        EditorPrefs.SetBool("writingYellow", writingYellow);
        EditorPrefs.SetBool("writingGreen", writingGreen);
        EditorPrefs.SetBool("writingBlue", writingBlue);
        EditorPrefs.SetBool("writingCyan", writingCyan);
        EditorPrefs.SetBool("writingMagenta", writingMagenta);
        EditorPrefs.SetBool("writingOrange", writingOrange);
        EditorPrefs.SetBool("writingOlive", writingOlive);
        EditorPrefs.SetBool("writingPurple", writingPurple);
        EditorPrefs.SetBool("writingGray", writingGray);

    }

    public static void WriteLoad()
    {

        writing = EditorPrefs.GetBool("writing");
        writingWarning = EditorPrefs.GetBool("writingWarning");
        writingError = EditorPrefs.GetBool("writingError");
        writingRed = EditorPrefs.GetBool("writingRed");
        writingYellow = EditorPrefs.GetBool("writingYellow");
        writingGreen = EditorPrefs.GetBool("writingGreen");
        writingBlue = EditorPrefs.GetBool("writingBlue");
        writingCyan = EditorPrefs.GetBool("writingCyan");
        writingMagenta = EditorPrefs.GetBool("writingMagenta");
        writingOrange = EditorPrefs.GetBool("writingOrange");
        writingOlive = EditorPrefs.GetBool("writingOlive");
        writingPurple = EditorPrefs.GetBool("writingPurple");
        writingGray = EditorPrefs.GetBool("writingGray");

    }





}
#endif

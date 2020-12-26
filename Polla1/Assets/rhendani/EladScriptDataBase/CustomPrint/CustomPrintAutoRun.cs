using UnityEditor;
#if UNITY_EDITOR

[InitializeOnLoad]
public class CustomPrintAutoRun
{

    static CustomPrintAutoRun()
    {
        WritingWindow.WriteLoad();
    }

}
#endif


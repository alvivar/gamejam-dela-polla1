using UnityEditor;
#if UNITY_EDITOR

[InitializeOnLoad]
public class ShowInfoAutoRun
{

    static ShowInfoAutoRun()
    {
        ShowInfoWindow.Load();
    }

}
#endif


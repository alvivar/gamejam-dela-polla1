using UnityEngine;


public class ShowInfoAttribute : PropertyAttribute
{

    public string writing;
    public bool working = false;
    public ShowInfoColor color;

    public ShowInfoAttribute(string write)
    {
#if UNITY_EDITOR
        writing = write;
#endif
    }

    public ShowInfoAttribute(string write, ShowInfoColor c)
    {
#if UNITY_EDITOR
        writing = write;
        working = true;
        color = c;
#endif
    }

}
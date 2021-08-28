using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MiniTarea
{

    public bool active;
    [Space(15)]
    public int importance;
    [TextArea(0,5)]
    public string description;

    [Space(15)]
    public Object script001;
    public Object script002;
    public Object script003;
    public Object script004;

}

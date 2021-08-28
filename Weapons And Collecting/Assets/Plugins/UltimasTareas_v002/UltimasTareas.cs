using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UN SCRIPTABLE OBJECT PARA ANOTAR LA ULTIMA TAREA

[CreateAssetMenu(fileName = "UltimaTarea", menuName = "Scriptable Objects/UltimaTarea", order = 2)]
public class UltimasTareas : ScriptableObject
{

    [ShowInfo("ANOTACIONES", ShowInfoColor.GrayDark)]
    [Space(10)]
    [TextArea(10,20)]
    public string Tareas;

    [Space(10)]
    [ShowInfo("CONECCIONES", ShowInfoColor.GrayDark)]
    [Space(10)]

    public Object simple001;
    public Object simple002;
    public Object simple003;
    public Object simple004;

    [Space(10)]

    public MiniTarea advanced001;
    public MiniTarea advanced002;
    public MiniTarea advanced003;
    public MiniTarea advanced004;

}

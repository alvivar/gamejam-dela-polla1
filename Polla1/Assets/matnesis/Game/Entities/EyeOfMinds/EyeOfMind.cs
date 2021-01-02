using TMPro;
using UnityEngine;

// !Gigas
public class EyeOfMind : MonoBehaviour
{
    public TextMeshPro content;

    private void OnEnable()
    {
        EntitySet.AddEyeOfMind(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveEyeOfMind(this);
    }
}
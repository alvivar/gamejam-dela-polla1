using TMPro;
using UnityEngine;

// !Gigas
public class EyeOfMind : MonoBehaviour
{
    public TextMeshPro content;

    public enum State { None, EyeOfBorn, EyeOfMind }
    public State state = State.None;

    private void OnEnable()
    {
        EntitySet.AddEyeOfMind(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveEyeOfMind(this);
    }
}
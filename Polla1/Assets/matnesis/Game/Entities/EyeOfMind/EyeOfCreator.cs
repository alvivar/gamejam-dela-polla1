using UnityEngine;

// !Gigas
public class EyeOfCreator : MonoBehaviour
{
    public Arrayx<string> queue = Arrayx<string>.New(2);

    private void OnEnable()
    {
        EntitySet.AddEyeOfCreator(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveEyeOfCreator(this);
    }
}
using UnityEngine;

// !Gigas
public class EyeOfCreator : MonoBehaviour
{
    public bool show = false;
    public Arrayx<string> queue = Arrayx<string>.New(2);

    private void OnEnable()
    {
        EntitySet.AddEyeOfCreator(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveEyeOfCreator(this);
    }

    public void New(string name)
    {
        queue.Add(name);
    }
}
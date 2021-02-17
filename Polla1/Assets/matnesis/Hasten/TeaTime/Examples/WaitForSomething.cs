using UnityEngine;

public class WaitForSomething : MonoBehaviour
{
    public bool something = false;

    void Start()
    {
        var waitForSomething = this.tt()
            .Wait(() => something)
            .Add(() =>
            {
                Debug.Log($"Prelude at {Time.time}");
            })
            .Add(1.5f, () =>
            {
                Debug.Log($"Action at {Time.time}");
            });
    }
}

// 2021.02.16 10.57 pm
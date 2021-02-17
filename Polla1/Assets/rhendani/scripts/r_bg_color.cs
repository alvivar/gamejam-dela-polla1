using UnityEngine;

public class r_bg_color : MonoBehaviour
{
    public float weirdSpeed;
    public float waitTime;
    public bool skip;
    public Color one;
    public Color two;

    void Start()
    {
        Camera cam = GetComponent<Camera>();

        this.tt(name)
            .Loop(waitTime, (tt) =>
            {
                cam.backgroundColor = Color.LerpUnclamped(cam.backgroundColor, two, weirdSpeed * Time.deltaTime);

                if (skip)
                {
                    tt.Break();
                    skip = false;
                }
            })
            .Loop(waitTime, (tt) =>
            {
                cam.backgroundColor = Color.LerpUnclamped(cam.backgroundColor, one, weirdSpeed * Time.deltaTime);

                if (skip)
                {
                    tt.Break();
                    skip = false;
                }

            })
            .Repeat();
    }
}
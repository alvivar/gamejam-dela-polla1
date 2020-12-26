using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class r_bg_color : MonoBehaviour
{

    public float weirdSpeed;
    public float waitTime;
    public Color one;
    public Color two;

    void Start()
    {

        Camera cam = GetComponent<Camera>();
        cam.backgroundColor = two;

        this.tt(name).Loop(waitTime,
        (tt) => {

            cam.backgroundColor = Color.LerpUnclamped(cam.backgroundColor, two, weirdSpeed * Time.deltaTime);

        }).Loop(waitTime,
        (tt) => {

            cam.backgroundColor = Color.LerpUnclamped(cam.backgroundColor, one, weirdSpeed * Time.deltaTime);

        }).Repeat();

    }

}

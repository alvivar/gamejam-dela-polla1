using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class r_animator : MonoBehaviour
{

    public float waiting = 1;
    public List<Sprite> ani = new List<Sprite>();
    public Sprite moreAni1;
    public float scratchAniDuration = 1;
    public Sprite moreAni2;
    SpriteRenderer spr;
    int current = 0;

    void Start()
    {

        Animations().Play();
        spr = GetComponent<SpriteRenderer>();

    }

    TeaTime Animations()
    {
        return this.tt(name).Add(() => waiting / 60,
            (tt) => {

                current++;
                ReturnRange(0, ani.Count - 1);
                //w.c("Current Value _ " + current);
                spr.sprite = ani[current];

            }).Repeat();
    }


    void ReturnRange(int min, int max)
    {

        if (current > max) current = min;
        if (current < min) current = max;

    }


    public void AniIdle()
    {
        spr.sprite = moreAni1;
    }

    public void AniItch()
    {
        spr.sprite = moreAni2;

        this.tt(name).Reset().Add(() => scratchAniDuration,
            () => {
                spr.sprite = moreAni1;
            });
    }

}

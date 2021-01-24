using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class r_animator : MonoBehaviour
{

    public float waiting = 1;
    public bool idle = false;
    public List<Sprite> ani = new List<Sprite>();
    public Sprite moreAni1;
    public float scratchAniDuration = 1;
    public Sprite moreAni2;
    SpriteRenderer spr;
    int current = 0;

    bool activated1 = true;
    bool activated2 = true;
    bool ready = false;

    void Start()
    {

        spr = GetComponent<SpriteRenderer>();
        Animations().Play();

    }

    private void Update()
    {

        if (idle && activated1)
        {
            this.tt(name).Stop();
            Idle().Play();
            activated1 = false;
            activated2 = true;
        }
        else if (!idle && activated2)
        {

            this.tt(name).Stop();
            Animations().Play();
            activated1 = true;
            activated2 = false;
        }

    }

    TeaTime Animations()
    {
        spr.sprite = ani[ani.Count - 1];

        this.tt("fly").Reset().Pause();

        return this.tt("fly").Add(() => waiting / 60,
            (tt) => {

                current++;
                ReturnRange(0, ani.Count - 1);
                spr.sprite = ani[current];

            }).Repeat();
    }


    void ReturnRange(int min, int max)
    {

        if (current > max) current = min;
        if (current < min) current = max;

    }

    TeaTime Idle()
    {
        spr.sprite = moreAni1;

        print("INFO A ");

        this.tt("fly").Reset().Pause();

        return this.tt("fly").Add(9,
            (tt) => {

                spr.sprite = moreAni2;

            }).Add(1,
            (tt) => {

                spr.sprite = moreAni1;

            }).Repeat();
    }



    //public void AniIdle()
    //{
    //    spr.sprite = moreAni1;
    //    this.tt(name).Reset().Add(() => scratchAniDuration,
    //    () => {
    //        spr.sprite = moreAni1;
    //    });
    //}
    //public void AniIdle()
    //{
    //    spr.sprite = moreAni2;


    //    this.tt(name).Reset().Add(() => scratchAniDuration,
    //        () => {
    //            spr.sprite = moreAni1;
    //        });
    //}


    public void MovementStay(Vector3 tanger)
    {

        // - - MovementStay -
        transform.position = new Vector3(12,2.2f,0);
        LeanTween.move(gameObject, tanger, 12);

        print("THE MOVEMENT STAY " + name);
        spr = GetComponent<SpriteRenderer>();
        Animations().Play();
        float randomWait = Random.Range(15f,100f);
        this.tt("Movement").Reset().Pause();

        this.tt("Movement").Play();

        this.tt("Movement").Add(12,
            (tt) =>
            {
                print("Next Phase 1");
                gameObject.transform.position = tanger;
                Idle().Play();

            }).Add(() => randomWait,
            (tt) =>
            {

                print("Next Phase 2");
                tanger = new Vector3(-12, 2.2f, 0);
                LeanTween.move(gameObject, tanger, 12);
                Animations().Play();

            }).Add(12,
            (tt) =>
            {

                print("Next Phase 3");
                gameObject.SetActive(false);

            });

    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class r_tree_component : MonoBehaviour
{

    [HideInInspector]
    public float waiting;
    [ShowInfo("Trees")]
    public Sprite phase1;
    public Sprite phase2;
    public Sprite phase3;
    public Sprite phase4;
    public Sprite phase5;

    [ShowInfo("Tangerines")]
    public List<Transform> tangerines;

    public Action tangerineActivation;

    int enabledTangerines = 0;
    //int tangerineTarget = 0;
    List<int> tangerinesGenerated = new List<int>();

    public void Start()
    {

        SpriteRenderer spr = GetComponent<SpriteRenderer>();


        spr.sprite = phase1;



        this.tt(name).Add(waiting,
            (tt) => {

                spr.sprite = phase2;

            }).Add(waiting,
            (tt) => {

                spr.sprite = phase3;

            }).Add(waiting,
            (tt) => {

                spr.sprite = phase4;

            }).Add(waiting,
            (tt) => {

                spr.sprite = phase5;

            }).Add(waiting,
            (tt) => {

                // 1
                StartCoroutine(GenRandomTangerine());
                tangerineActivation.Invoke();

            }).Add(waiting,
            (tt) => {


                // 2
                StartCoroutine(GenRandomTangerine());


            }).Add(waiting,
            (tt) => {

                // 3
                StartCoroutine(GenRandomTangerine());

            }).Add(waiting,
            (tt) => {

                // 4
                StartCoroutine(GenRandomTangerine());

            });


    }



    IEnumerator GenRandomTangerine()
    {

        bool working = true;

        while (working)
        {

            int gen = UnityEngine.Random.Range( 0, tangerines.Count);
            yield return new WaitForFixedUpdate();

            if (!tangerinesGenerated.Contains(gen))
            {

                tangerines[gen].gameObject.SetActive(true); 
                tangerinesGenerated.Add(gen); 
                working = false;

            }
            else if (tangerinesGenerated.Count == tangerines.Count)
            {

                working = false;

            }

        }

    }


}

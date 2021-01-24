using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class r_tree_component : MonoBehaviour
{

    [HideInInspector]
    public float waitingInfo;
    [ShowInfo("Trees")]
    public Sprite phase1;
    public Sprite phase2;
    public Sprite phase3;
    public Sprite phase4;
    public Sprite phase5;
    public Sprite phase6;

    [ShowInfo("Tangerines")]
    public List<Transform> tangerines;

    public Action tangerineActivation;

    int enabledTangerines = 0;
    //int tangerineTarget = 0;
    List<int> tangerinesGenerated = new List<int>();
    public bool hack = false;

    public void OnEnable()
    {

        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        spr.sprite = phase1;
        this.tt(name).Add(() => waitingInfo,
            (tt) =>
            {

                spr.sprite = phase2;
                if (hack)
                {
                    waitingInfo = 0.5f;
                }

            }).Add(() => waitingInfo,
            (tt) =>
            {

                spr.sprite = phase3;
                if (hack)
                {
                    waitingInfo = 0.5f;
                }

            }).Add(() => waitingInfo,
            (tt) =>
            {

                spr.sprite = phase4;
                if (hack)
                {
                    waitingInfo = 0.5f;
                }

            }).Add(() => waitingInfo,
            (tt) =>
            {

                spr.sprite = phase5;
                if (hack)
                {
                    waitingInfo = 0.5f;
                }

            }).Add(() => waitingInfo,
            (tt) =>
            {

                // 1
                StartCoroutine(GenRandomTangerine());
                tangerineActivation.Invoke();
                if (hack)
                {
                    waitingInfo = 0.5f;
                }

            }).Add(() => waitingInfo,
            (tt) =>
            {

                // 2
                StartCoroutine(GenRandomTangerine());
                tangerineActivation.Invoke();
                if (hack)
                {
                    waitingInfo = 0.5f;
                }

            }).Add(() => waitingInfo,
            (tt) =>
            {

                // 3
                StartCoroutine(GenRandomTangerine());
                tangerineActivation.Invoke();
                if (hack)
                {
                    waitingInfo = 0.5f;
                }

            }).Add(() => waitingInfo,
            (tt) =>
            {

                // 4
                StartCoroutine(GenRandomTangerine());
                tangerineActivation.Invoke();


            }).Add(() => waitingInfo * 2,
            (tt) =>
            {
                // Alive Time 1
                StartCoroutine(HideRandomTangerine());


            }).Add(() => 12,
            (tt) =>
            {
                // Alive Time 2
                StartCoroutine(HideRandomTangerine());


            }).Add(() => 12,
            (tt) =>
            {
                // Alive Time 3
                StartCoroutine(HideRandomTangerine());


            }).Add(() => 12,
            (tt) =>
            {

                // Alive Time 4
                HideAll();


            }).Add(() => 12,
            (tt) =>
            {
                // Alive Time 4
                spr.sprite = phase6;


            }).Add(() => 12 * 2,
            (tt) =>
            {
                // Alive Time 4
                gameObject.SetActive(false);
            });
    }

    IEnumerator GenRandomTangerine()
    {

        bool working = true;

        while (working)
        {

            int gen = UnityEngine.Random.Range(0, tangerines.Count);
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

    void HideAll()
    {
        for (int i = 0; i < tangerines.Count; i++)
        {
            tangerines[i].gameObject.SetActive(false);
        }
    }

    IEnumerator HideRandomTangerine()
    {

        bool working = true;

        while (working)
        {
            int gen = UnityEngine.Random.Range(0, tangerinesGenerated.Count + 1);
            yield return new WaitForFixedUpdate();
            // write.g("Current Gen _ " + gen);
            // write.ol("Current Count _ " + tangerinesGenerated.Count);

            if (tangerinesGenerated.Contains(gen))
            {

                // write.y("Is Active _ " + tangerines[gen].gameObject.activeSelf);
                // write.o("Contains _ " + tangerinesGenerated.Contains(gen));
                // write.gr("Removing _ " + tangerines[gen].name);

                tangerinesGenerated.Remove(gen);
                tangerines[gen].gameObject.SetActive(false);

                // write.y("Is Active _ " + tangerines[gen].gameObject.activeSelf);
                // write.o("Contains _ " + tangerinesGenerated.Contains(gen));

                working = false;

            }
            else if (tangerinesGenerated.Count == 0)
            {

                working = false;

            }
        }
    }
}
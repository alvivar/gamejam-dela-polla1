using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class r_start_component : MonoBehaviour
{


    public bool skip;
    public r_cloud_handler clouds;
    public List<GameObject> show;
    public List<GameObject> hide;



    private void Start()
    {
        if (skip)
        {
            clouds.VisibleClouds(Color.white);
            SetReady();
        }
    }





    public void SetReady()
    {

        for (int i = 0; i < show.Count; i++)
        {
            show[i].SetActive(true);
        }

        for (int i = 0; i < hide.Count; i++)
        {
            hide[i].SetActive(false);
        }

    }


}

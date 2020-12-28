using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyOnLoad : MonoBehaviour
{
    //[HideInInspector]
    //public bool activated = false;
    public int code;
    int startCode;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        startCode = code;
        code = -1;
    }

    void OnLevelWasLoaded()
    {


        DoNotDestroyOnLoad[] finding = FindObjectsOfType<DoNotDestroyOnLoad>();

        foreach(DoNotDestroyOnLoad don in finding)
        {
            if (don.code == startCode) Destroy(don.gameObject);
        }

        //code = -1;
        //activated = true;

    }
}

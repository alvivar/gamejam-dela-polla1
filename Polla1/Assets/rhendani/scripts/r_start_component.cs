using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class r_start_component : MonoBehaviour
{

    public GameObject mouseComponent;
    public GameObject cloudsComponent;
    public GameObject tangerinePower;
    public GameObject gameDirt;
    public GameObject tangerine;


    public void SetReady()
    {
        mouseComponent.SetActive(true);
        cloudsComponent.SetActive(true);
        tangerinePower.SetActive(true);
        gameDirt.SetActive(true);
        tangerine.SetActive(false);
    }


}

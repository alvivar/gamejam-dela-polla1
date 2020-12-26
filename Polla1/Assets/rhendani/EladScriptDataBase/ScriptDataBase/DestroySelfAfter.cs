using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfAfter : MonoBehaviour
{

    public float duration = 1;

    void Start()
    {
        Destroy(gameObject, duration);
    }

}

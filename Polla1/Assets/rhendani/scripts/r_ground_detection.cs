using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class r_ground_detection : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //write.b("_ ENTERING 0 " + name);

    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        write.b("_ ENTERING 0 " + name);

    }


}

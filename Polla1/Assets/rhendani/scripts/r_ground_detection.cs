using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class r_ground_detection : MonoBehaviour
{

    public r_power_up_handler powerUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //write.b("_ ENTERING 0 " + name);

    }




    private void OnCollisionEnter2D(Collision2D collision)
    {

        powerUp.SeedActivation(collision.transform.position);


        collision.transform.position = Vector3.one * 99;
        collision.gameObject.SetActive(false);


        bool asd = EditorGUIUtility.isProSkin;

        write.b("_ ENTERING " + name);

    }


}

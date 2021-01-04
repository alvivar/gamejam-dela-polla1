using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class r_ground_detection : MonoBehaviour
{

    public ParticleSystem particle;
    public RaySoundHandler sound;
    public r_power_up_handler powerUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //write.b("_ ENTERING 0 " + name);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 pos = new Vector3(collision.transform.position.x, -3.32f, collision.transform.position.z);

        powerUp.SeedActivation(pos);
        sound.PlaySound("8sw");

        particle.transform.position = pos;
        particle.Play();

        collision.transform.position = Vector3.one * 99;
        collision.gameObject.SetActive(false);

        // bool asd = EditorGUIUtility.isProSkin;

    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class r_seed_component : MonoBehaviour
{

    public float speed;
    public float speedAdd;
    public float waiting;

    float currentSpeed;


    void OnEnable()
    {
        currentSpeed = speed;

        this.tt(name).Restart().Add(waiting,
            (tt) => {

                currentSpeed += speedAdd;
            
            }).Repeat();

    }


    void Update()
    {

        transform.position += new Vector3(0, -1, 0) * currentSpeed * Time.deltaTime;

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        write.b("_ ENTERING " + name);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //write.b("_ ENTERING 0 " + name);

    }

    private void OnBecameInvisible()
    {
        this.tt(name).Stop();
        currentSpeed = speed;
        gameObject.SetActive(false);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class r_cloud_handler : MonoBehaviour
{


    public float waitCloud = 1;
    public float spawnRadius = 1;
    public Vector2 randomSpeed;
    public List<r_cloud_state> clouds;


    private void Start()
    {

        this.tt(name).Add(waitCloud,
            (tt) => {

                SpawnCloud();

            }).Repeat();

    }


    void Update()
    {

        for (int i = 0; i < clouds.Count; i++)
        {

            if (clouds[i].isRight)
            {
                clouds[i].transform.position += new Vector3(-1,0,0) * clouds[i].speed * Time.deltaTime;
            }
            else
            {
                clouds[i].transform.position += new Vector3(1,0,0) * clouds[i].speed * Time.deltaTime;
            }

        }
    }


    void SpawnCloud()
    {
        int activeSeedsNum = 0;


        for (int i = 0; i < clouds.Count; i++)
        {
            if (clouds[i].gameObject.activeSelf)
            {
                activeSeedsNum++;
            }
        }

        for (int i = 0; i < clouds.Count; i++)
        {

            if (!clouds[i].gameObject.activeSelf)
            {
                int right = Random.Range(0, 2);

                if(right == 0)
                {
                    clouds[i].isRight = true;
                }
                else if (right == 1)
                {
                    clouds[i].isRight = false;
                }
                else
                {
                    write.c("0 ERROR _ " + name); 
                }

                clouds[i].speed = Random.Range(randomSpeed.x, randomSpeed.y);


                Vector3 pos = Vector3.zero;

                if (clouds[i].isRight)
                {
                    pos = new Vector3(10,0,0);
                }
                else
                {
                    pos = new Vector3(-10, 0, 0);
                }


                pos += Random.insideUnitSphere * spawnRadius;
                clouds[i].transform.position = pos;

                clouds[i].gameObject.SetActive(true);

                break;
            }

        }

    }

    public void VisibleClouds(Color value)
    {
        for (int i = 0; i < clouds.Count; i++)
        {
            clouds[i].GetComponent<SpriteRenderer>().color = value;
        }
    }

}

using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class r_bird_control : MonoBehaviour
{


    public List<GameObject> bird = new List<GameObject>();

    bool disabled = false;
    int disableInt = 0;

    public void Start()
    {

        this.tt("birds").Add(2,
        (tt) => {

            if (!disabled)
            {
                int randos = Random.Range(0, 100);

                if (randos < 7)
                {

                    GameObject[] objs = GameObject.FindGameObjectsWithTag("TANGERINE");
                    print("TANGERINES   " + objs.Length);

                    if (objs.Length > 7)
                    {
                        for (int i = 0; i < bird.Count; i++)
                        {



                            if (!bird[i].gameObject.activeSelf)
                            {

                                int randTang = Random.Range(0, objs.Length - 1);
                                print("TANGERINE FOUND   " + randTang);
                                Vector3 pos = objs[randTang].transform.position; 


                                bird[i].gameObject.SetActive(true);
                                bird[i].GetComponent<r_animator>().MovementStay(new Vector3(pos.x, pos.y + 0.15f, pos.z));
                                disabled = true;
                                break;

                            }
                        }
                    }
                }
            }
            else
            {
                disableInt++;
                if (disableInt == 20)
                {
                    disableInt = 0;
                    disabled = false;
                }
            }


        }).Repeat();

    }

}

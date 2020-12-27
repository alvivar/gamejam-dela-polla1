using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class r_mouse_input : MonoBehaviour
{

    public int maxSeeds = 1;
    public Camera cam;
    public List<GameObject> seeds;

    private void OnMouseOver()
    {
        
        if (Input.GetMouseButtonDown(0))
        {

            int activeSeedsNum = 0;

            for (int i = 0; i < seeds.Count; i++)
            {
                if (seeds[i].activeSelf)
                {
                    activeSeedsNum++;
                }
            }

            //write.b("_ 0 " + activeSeedsNum);
            //write.b("_ 0 " + seeds.Count);

            Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 targetPos = new Vector3(pos.x,pos.y,0);

            if (activeSeedsNum < maxSeeds)
            {
                for (int i = 0; i < seeds.Count; i++)
                {

                    if (!seeds[i].activeSelf)
                    {
                        seeds[i].SetActive(true);
                        seeds[i].transform.position = targetPos;
                        break;
                    }

                }

            }

        }

    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void OnBecameInvisible()
    {
        
    }

    private void OnBecameVisible()
    {
        
    }

}

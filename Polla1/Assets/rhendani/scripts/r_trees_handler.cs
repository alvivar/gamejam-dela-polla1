using System.Collections.Generic;
using UnityEngine;
using System;

public class r_trees_handler : MonoBehaviour
{

    public float waiting;
    public List<r_tree_component> trees;

    private void Start()
    {
        for (int i = 0; i < trees.Count; i++)
        {
            trees[i].waiting = waiting;
        }
    }

    public void SpawnTree(Vector3 pos, Action powerUp)
    {

        for (int i = 0; i < trees.Count; i++)
        {

            if (!trees[i].gameObject.activeSelf)
            {

                trees[i].transform.position = pos;
                trees[i].gameObject.SetActive(true);
                trees[i].tangerineActivation = powerUp;

                break;
            }

        }

    }

}

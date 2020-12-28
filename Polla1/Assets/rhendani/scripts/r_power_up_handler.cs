using UnityEngine;
using UnityEngine.UI;

public class r_power_up_handler : MonoBehaviour
{

    // public r_tree_component singleTree;

    public Text input;
    public r_trees_handler treeHandler;
    public r_mouse_input output;


    public void SeedActivation(Vector3 pos)
    {

        treeHandler.SpawnTree(pos,
            ()=> {

                write.c("0 POWER UP _ " + name);
                output.maxSeeds = int.Parse(input.text) + 1;
                input.text = output.maxSeeds.ToString();

            });

    }

    
}

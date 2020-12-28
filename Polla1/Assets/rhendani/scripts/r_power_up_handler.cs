using UnityEngine;
using UnityEngine.UI;

public class r_power_up_handler : MonoBehaviour
{

    // public r_tree_component singleTree;

    public Text input;
    public r_trees_handler treeHandler;
    public r_mouse_input output;

    int storedTangerines = 0;
    int outputValue = 1;

    public void SeedActivation(Vector3 pos)
    {

        treeHandler.SpawnTree(pos,
            ()=> {

                write.c("0 POWER UP _ " + name);
                storedTangerines++;

                switch(storedTangerines)
                {

                    case 1:
                        outputValue = 2;
                        break;
                    case 5:
                        outputValue = 3;
                        break;
                    case 10:
                        outputValue = 4;
                        break;
                    case 15:
                        outputValue = 5;
                        break;
                    case 20:
                        outputValue = 6;
                        break;
                    case 25:
                        outputValue = 7;
                        break;
                    case 30:
                        outputValue = 8;
                        break;
                    case 35:
                        outputValue = 9;
                        break;
                    case 40:
                        outputValue = 10;
                        break;

                }

                output.maxSeeds = outputValue;
                input.text = output.maxSeeds.ToString();

            });

    }

    
}

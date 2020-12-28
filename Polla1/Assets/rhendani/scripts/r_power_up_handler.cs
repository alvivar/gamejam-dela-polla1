using UnityEngine;
using UnityEngine.UI;

public class r_power_up_handler : MonoBehaviour
{

    // public r_tree_component singleTree;

    public Text input;
    public RaySoundHandler sound;
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
                        sound.PlaySound("powerup");
                        outputValue = 2;
                        break;
                    case 5:
                        sound.PlaySound("powerup");
                        outputValue = 3;
                        break;
                    case 10:
                        sound.PlaySound("powerup");
                        outputValue = 4;
                        break;
                    case 20:
                        sound.PlaySound("powerup");
                        outputValue = 5;
                        break;
                    case 30:
                        sound.PlaySound("powerup");
                        outputValue = 6;
                        break;
                    case 35:
                        sound.PlaySound("powerup");
                        outputValue = 7;
                        break;
                    case 40:
                        sound.PlaySound("powerup");
                        outputValue = 8;
                        break;
                    case 50:
                        sound.PlaySound("powerup");
                        outputValue = 9;
                        break;
                    case 60:
                        sound.PlaySound("powerup");
                        outputValue = 10;
                        break;
                    case 75:
                        sound.PlaySound("powerup");
                        outputValue = 11;
                        break;
                    case 100:
                        sound.PlaySound("powerup");
                        outputValue = 12;
                        break;
                    case 125:
                        sound.PlaySound("powerup");
                        outputValue = 13;
                        break;
                    case 150:
                        sound.PlaySound("powerup");
                        outputValue = 14;
                        break;
                    case 200:
                        sound.PlaySound("powerup");
                        outputValue = 15;
                        break;

                }

                output.maxSeeds = outputValue;
                input.text = output.maxSeeds.ToString();

            });

    }

    
}

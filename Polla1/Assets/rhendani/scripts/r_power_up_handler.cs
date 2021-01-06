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
    float speedThrow = 0.35f;


    public void SetPower()
    {
        input.text = output.maxSeeds.ToString();
    }


    public void SeedActivation(Vector3 pos)
    {

        treeHandler.SpawnTree(pos,
            ()=> {

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
                        speedThrow = 0.325f;
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
                        speedThrow = 0.30f;
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
                        speedThrow = 0.275f;
                        break;
                    case 250:
                        sound.PlaySound("powerup");
                        outputValue = 16;
                        break;
                    case 300:
                        sound.PlaySound("powerup");
                        outputValue = 17;
                        break;
                    case 400:
                        sound.PlaySound("powerup");
                        outputValue = 18;
                        break;
                    case 600:
                        sound.PlaySound("powerup");
                        outputValue = 19;
                        break;
                    case 800:
                        sound.PlaySound("powerup");
                        outputValue = 20;
                        speedThrow = 0.250f;
                        break;
                    case 1000:
                        sound.PlaySound("powerup");
                        outputValue = 21;
                        break;
                    case 1200:
                        sound.PlaySound("powerup");
                        outputValue = 22;
                        break;
                    case 1500:
                        sound.PlaySound("powerup");
                        outputValue = 23;
                        break;
                    case 1750:
                        sound.PlaySound("powerup");
                        outputValue = 24;
                        break;
                    case 2000:
                        sound.PlaySound("powerup");
                        outputValue = 25;
                        speedThrow = 0.225f;
                        break;
                    case 2500:
                        sound.PlaySound("powerup");
                        outputValue = 26;
                        break;
                    case 3000:
                        sound.PlaySound("powerup");
                        outputValue = 27;
                        break;
                    case 3600:
                        sound.PlaySound("powerup");
                        outputValue = 28;
                        break;
                    case 4200:
                        sound.PlaySound("powerup");
                        outputValue = 29;
                        break;
                    case 5000:
                        sound.PlaySound("powerup");
                        outputValue = 30;
                        speedThrow = 0.20f;
                        break;
                }

                IntFile createNew = new IntFile();
                createNew.value = outputValue;
                SerializeIntValue.S(createNew);

                output.autoSpeed = speedThrow;
                output.maxSeeds = outputValue;
                input.text = output.maxSeeds.ToString();

            });

    }

    
}

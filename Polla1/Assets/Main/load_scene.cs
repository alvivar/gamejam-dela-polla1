using UnityEngine;
using UnityEngine.SceneManagement;

public class load_scene : MonoBehaviour
{
    public void LoadGame(int value)
    {

        SceneManager.LoadScene(value, LoadSceneMode.Single);

    }
    
}

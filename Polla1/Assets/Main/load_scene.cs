using UnityEngine;
using UnityEngine.SceneManagement;

public class load_scene : MonoBehaviour
{
    public int scene;

    public void LoadGame()
    {

        SceneManager.LoadScene(scene, LoadSceneMode.Single);

    }
    
}

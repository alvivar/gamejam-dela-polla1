using UnityEngine;
using UnityEngine.SceneManagement;

public class exit_component : MonoBehaviour
{

    public void Exit()
    {

        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);

    }
    
}

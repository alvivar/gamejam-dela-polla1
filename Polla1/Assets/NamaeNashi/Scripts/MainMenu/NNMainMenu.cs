using UnityEngine;
using UnityEngine.SceneManagement;
using NamaeNashi;

namespace NamaeNashi{
    public class NNMainMenu : MonoBehaviour{

        public NNMainMenuMinigame miniGame;

        public GameObject instruccions;
        public GameObject mainMenu;

        public string gameScene;
        public int sceneManager;


        public void StartGame() { 
            SceneManager.LoadScene(gameScene);
        }

        public void GoBack() {
            SceneManager.LoadScene(sceneManager);
        }
        
        public void StartMinigame() {
            miniGame.RestartMinigame();
        }

        public void Instructions() {
            instruccions.SetActive(true);
            mainMenu.SetActive(false);
        }

        public void RestartMainMenu() {
            instruccions.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}

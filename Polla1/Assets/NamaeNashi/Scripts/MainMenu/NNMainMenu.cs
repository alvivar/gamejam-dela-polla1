using UnityEngine;
using UnityEngine.SceneManagement;
using NamaeNashi;

namespace NamaeNashi{
    public class NNMainMenu : MonoBehaviour{

        public AudioSource mainMenuSounds;
        public AudioClip goNextSound;
        public AudioClip goBackSound;
        public NNMainMenuMinigame miniGame;

        public GameObject instruccions;
        public GameObject mainMenu;

        public string gameScene;
        public int sceneManager;


        public void StartGame() { 
            SceneManager.LoadScene(gameScene);
            mainMenuSounds.PlayOneShot(goNextSound);
        }

        public void GoBack() {
            mainMenuSounds.PlayOneShot(goBackSound);
            SceneManager.LoadScene(sceneManager);
        }
        
        public void StartMinigame() {
            miniGame.RestartMinigame();
            mainMenuSounds.PlayOneShot(goNextSound);
        }

        public void Instructions() {
            instruccions.SetActive(true);
            mainMenu.SetActive(false);
            mainMenuSounds.PlayOneShot(goNextSound);
        }

        public void RestartMainMenu() {
            instruccions.SetActive(false);
            mainMenu.SetActive(true);
            mainMenuSounds.PlayOneShot(goBackSound);
        }
    }
}

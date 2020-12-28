using UnityEngine;
using UnityEngine.SceneManagement;
using NamaeNashi;

namespace NamaeNashi{
    public class NNMainMenu : MonoBehaviour{
        public NNMainMenuMinigame miniGame;

        public GameObject instruccions;
        public GameObject mainMenu;
        public GameObject ParrotMenu;

        public string gameScene;
        public int sceneManager;


        public void StartGame() { 
            SceneManager.LoadScene(gameScene);
            AudioMaster.Instance.PlayMenuSound();
        }

        public void GoBack() {
            AudioMaster.Instance.PlayMenuSound();
            SceneManager.LoadScene(sceneManager);
        }
        
        public void StartMinigame() {
            miniGame.RestartMinigame();
            AudioMaster.Instance.PlayMenuSound();
        }

        public void Instructions() {
            instruccions.SetActive(true);
            mainMenu.SetActive(false);
            AudioMaster.Instance.PlayMenuSound();
        }

        public void RestartMainMenu() {
            instruccions.SetActive(false);
            mainMenu.SetActive(true);
            AudioMaster.Instance.PlayMenuSound();
        }

        public void BackToMainMenu(){ 
            for(int x=0;x<miniGame.levelItems.Length;++x) {
                miniGame.levelItems[x].level.SetActive(false);
            }
            AudioMaster.Instance.PlayMenuSound();
        }

        public void OpenParrotMenu(){
            mainMenu.SetActive(false);
            ParrotMenu.SetActive(true);
            AudioMaster.Instance.PlayMenuSound();
        }

        public void ExitParrotMenu() {
            mainMenu.SetActive(true);
            ParrotMenu.SetActive(false);
            AudioMaster.Instance.PlayMenuSound();
        }
    }
}

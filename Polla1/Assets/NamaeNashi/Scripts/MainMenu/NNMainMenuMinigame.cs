using NamaeNashi;
using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace NamaeNashi {
    public class NNMainMenuMinigame : MonoBehaviour {

        public NNMainMenu mainMenu;
        public NNMainMenuLevelScriptable mainMenuScriptable;
        public GameObject pityMenu;
        public GameObject[] levels;
        public GameObject[] levelButton;
        public GameObject[] correctTriesGO;

        private int currentLvl=-1;
        private int wrongTries=3;
        private int correctTries = 0;

        public void SelectedCorrect(){
            correctTries++;
            if(correctTries!=mainMenuScriptable.correctAnswersToEnterGame) {
                GoToNextLevel();
            }else{
                mainMenu.StartGame();
            }
        }

        public void StartMiniGame() {
            correctTries=0;
            wrongTries=mainMenuScriptable.wrongTries;
            currentLvl=0;
            for(int x=0;x<levels.Length;++x) {
                levels[x].SetActive(false);
            }
            RefreshCorrectTries();
            StartLevel();
        }

        public void StartLevel(){
            RefreshCorrectTries();
            if (currentLvl!=0){
                levels[currentLvl-1].SetActive(false);
            }
            levels[0].SetActive(true);
        }

        public void SelectedWrongOption(){
            --wrongTries;
            if(wrongTries>0){
                GoToNextLevel();
            }else {
                for (int x = 0; x<levels.Length; ++x) {
                    levels[x].SetActive(false);
                }
                pityMenu.SetActive(true);
            }
        }

        public void GoToNextLevel(){
            ++currentLvl;
            StartLevel();
        }

        public void RestartMinigame(){
            StartMiniGame();
        }

        private void RefreshCorrectTries(){
            bool tempValue;
            for (int x = 0; x<correctTriesGO.Length; ++x) {
                if(x<correctTries) {
                    tempValue=true;
                } else {
                    tempValue=false;
                }
                correctTriesGO[x].SetActive(tempValue);
            }
        }
    }

    //public I
}

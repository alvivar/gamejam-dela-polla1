using NamaeNashi;
using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace NamaeNashi {
    public class NNMainMenuMinigame : MonoBehaviour {

        [System.Serializable]
        public struct LevelItems{
            public GameObject level;
            public RectTransform levelButton;
            public RectTransform[] extraItems;
        }

        public NNMainMenu mainMenu;
        public NNMainMenuLevelScriptable mainMenuScriptable;
        public GameObject pityMenu;
        public LevelItems[] levelItems;        
       // public GameObject[] correctTriesGO;
        private int currentLvl=-1;
        private int wrongTries=3;
        private int correctTries = 0;

        private IEnumerator correctButtonCoroutine;
        private IEnumerator extraItemsCoroutine;

        public int startFromLevel=-1;
        public AudioSource mainMenuSounds;
        public AudioClip correctSound;
        public AudioClip failSound;

        public void SelectedCorrect(){
            /*correctTries++;
            if(correctTries!=mainMenuScriptable.correctAnswersToEnterGame) {
                GoToNextLevel();
            }else{
                mainMenu.StartGame();
            }*/
            mainMenuSounds.PlayOneShot(correctSound);
            GoToNextLevel();
        }

        public void StartMiniGame() {
            correctTries=0;
            wrongTries=mainMenuScriptable.wrongTries;
            currentLvl=startFromLevel;
            AudioMaster.Instance.ChangeSongLevel(0);
            for (int x=0;x<levelItems.Length;++x) {
                if(levelItems[x].level!=null){
                    levelItems[x].level.SetActive(false);
                }
            }
            //RefreshCorrectTries();
            StartLevel();
        }

        public void StartLevel() {

            correctButtonCoroutine=MovingItems();
            extraItemsCoroutine=MovingExtraItems();
            StartCoroutine(correctButtonCoroutine);
            StartCoroutine(extraItemsCoroutine);
            //RefreshCorrectTries();
            for (int x = 0; x<levelItems.Length; ++x) {
                if (levelItems[x].level!=null) {
                    levelItems[x].level.SetActive(false);
                }
            }
            levelItems[currentLvl].level.SetActive(true);

        }
        /*
        public void SelectedWrongOption(){
            --wrongTries;
            if(wrongTries>0){
                GoToNextLevel();
            }else {
                for (int x = 0; x<levelItems.Length; ++x) {
                    levelItems[x].level.SetActive(false);
                }
                pityMenu.SetActive(true);
            }
        }*/

        public void SelectedWrong() {
            mainMenuSounds.PlayOneShot(failSound);
            /*TO DO*/
        }

        public void GoToNextLevel(){
            if(currentLvl<levelItems.Length) {
                StopCoroutine(correctButtonCoroutine);
                StopCoroutine(extraItemsCoroutine);
                ++currentLvl;
                RefreshSound();
                StartLevel();
            }else{ 
            
            }
        }

        public void RefreshSound(){

            float musicTier0= levelItems.Length/3;
            float musicTier1= 2*levelItems.Length/3;


            if (currentLvl<musicTier0) {
                AudioMaster.Instance.ChangeSongLevel(0);
            } else if(currentLvl<musicTier1) {
                AudioMaster.Instance.ChangeSongLevel(1);
            } else {
                AudioMaster.Instance.ChangeSongLevel(2);
            }
        }

        public void RestartMinigame(){
            StartMiniGame();
        }
        /*
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
        }*/

        private IEnumerator MovingItems() {
            int currentAnimNumber = mainMenuScriptable.movementLocations[currentLvl].startingNum;
            levelItems[currentLvl].levelButton.anchoredPosition=mainMenuScriptable.movementLocations[currentLvl].locationsPoint[currentAnimNumber];            
            while (true){
                ++currentAnimNumber;
                if (currentAnimNumber>=mainMenuScriptable.movementLocations[currentLvl].locationsPoint.Length) {
                    currentAnimNumber=0;
                }
                levelItems[currentLvl].levelButton.DOAnchorPos(mainMenuScriptable.movementLocations[currentLvl].locationsPoint[currentAnimNumber], mainMenuScriptable.movementLocations[currentLvl].timeMovement).SetEase(Ease.Linear); ;
                yield return new WaitForSeconds(mainMenuScriptable.movementLocations[currentLvl].timeMovement);
            }
        }

        private IEnumerator MovingExtraItems() {
            NNMainMenuLevelScriptable.MainMenuMovingItems[] tempLevelData;
            tempLevelData=mainMenuScriptable.movementLocations[currentLvl].movingExtraItems;
            int[] currentAnimNumber = new int[tempLevelData.Length];
            for (int x = 0; x<tempLevelData.Length; ++x) {
                currentAnimNumber[x]=tempLevelData[x].startingNum;levelItems[currentLvl].extraItems[x].anchoredPosition=tempLevelData[x].locationsPoint[currentAnimNumber[x]];
            }
            while (true) {
                for(int x=0;x<tempLevelData.Length;++x){
                    ++currentAnimNumber[x];
                    if(currentAnimNumber[x]>=tempLevelData[x].locationsPoint.Length) {
                        currentAnimNumber[x]=0;
                    }
                    levelItems[currentLvl].extraItems[x].DOAnchorPos(tempLevelData[x].locationsPoint[currentAnimNumber[x]], mainMenuScriptable.movementLocations[currentLvl].timeMovement).SetEase(Ease.Linear);
                }
                yield return new WaitForSeconds(mainMenuScriptable.movementLocations[currentLvl].timeMovement);
            }
        }
    }
}
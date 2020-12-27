using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NamaeNashi {
    [CreateAssetMenu(fileName = "MainMenuMinigame", menuName = "NamaeNashi/MainMenuMinigame", order = 1)]
    public class NNMainMenuLevelScriptable : ScriptableObject {
        [System.Serializable]
        public struct MainMenuLevel{
            public float timeMovement;
            public Vector2[] locationsPoint;
            public int startingNum;
            public MainMenuMovingItems[] movingExtraItems;
        }

        [System.Serializable]
        public struct MainMenuMovingItems{
            public Vector2[] locationsPoint;
            public int startingNum;
        }

        public int correctAnswersToEnterGame;
        public MainMenuLevel[] movementLocations;
        public int wrongTries;

        [ContextMenu("Shuffle at 5")]
        public void ShuffleLocationsAt5(){
            List<Vector2> newList = new List<Vector2>();
            for(int x=0;x<movementLocations[4].locationsPoint.Length;++x){
                newList.Add(movementLocations[4].locationsPoint[x]);
            }
            Shuffle(newList);
            for (int x = 0; x<movementLocations[4].locationsPoint.Length; ++x) {
                movementLocations[4].locationsPoint[x]=newList[x];
            }
            for(int x=0;x<movementLocations[4].movingExtraItems.Length;++x) {
                newList.Clear();
                for (int y = 0; y<movementLocations[4].movingExtraItems[x].locationsPoint.Length; ++y) {
                    newList.Add(movementLocations[4].movingExtraItems[x].locationsPoint[y]);
                }
                Shuffle(newList);
                for (int y = 0; y<movementLocations[4].movingExtraItems[x].locationsPoint.Length; ++y) {
                    movementLocations[4].movingExtraItems[x].locationsPoint[y]=newList[y];
                }
            }
        }

        [ContextMenu("duplicate list buttons")]
        public void CopyLvl5(){ 
            for(int x=0;x<movementLocations[4].movingExtraItems.Length;++x) {
                movementLocations[4].movingExtraItems[x].locationsPoint=new Vector2[movementLocations[4].locationsPoint.Length];
                for(int y=0;y<movementLocations[4].locationsPoint.Length; ++y){
                    movementLocations[4].movingExtraItems[x].locationsPoint[y]=movementLocations[4].locationsPoint[y];
                }
            }
        }

        public void Shuffle<T>(List<T> alpha) {
            for (int i = 0; i<alpha.Count; i++) {
                T temp = alpha[i];
                int randomIndex = Random.Range(i, alpha.Count);
                alpha[i]=alpha[randomIndex];
                alpha[randomIndex]=temp;
            }
        }
    }
}
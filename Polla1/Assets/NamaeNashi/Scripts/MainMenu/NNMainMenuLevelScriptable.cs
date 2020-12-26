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
            public float timeToNextTask;
        }

        public int correctAnswersToEnterGame;
        public MainMenuLevel[] movementLocations;
        public int wrongTries;
    }
}
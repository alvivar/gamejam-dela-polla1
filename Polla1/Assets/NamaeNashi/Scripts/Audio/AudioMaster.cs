using UnityEngine;
using NamaeNashi;
using DG.Tweening;
using System.Collections;

namespace NamaeNashi {
    public class AudioMaster : MonoBehaviour{

        [Range(0f,1f)]
        public float maxVolume;
        public float timeChangingSongs;

        public int startingSongLevel=2;

        public AudioSource[] audiosources;

        private Tween[] tweenMusic;

        public AudioSource music;

        private static AudioMaster instance;
        public static AudioMaster Instance {
            get {
                return instance;
            }
        }

        void Awake() {
            instance=this;
        }

        private void Start() {
            tweenMusic=new Tween[3];
            ChangeSongLevel(startingSongLevel);
        }


        public void ChangeSongLevel(int songNum){
            StartCoroutine(SwitchMusic(songNum));
        }

        private IEnumerator SwitchMusic(int songNum) {
            bool finished = false;
            float currentTime = 0f;
            float value = 0;
            while (!finished) {
                currentTime+=Time.deltaTime;
                value=Mathf.Lerp(0f, maxVolume, currentTime/timeChangingSongs);
                for (int x = 0; x<audiosources.Length; ++x) {
                    if (songNum!=x) {
                        if(audiosources[x].volume!=0){
                            audiosources[x].volume=maxVolume-value;
                        }
                    } else {
                        audiosources[x].volume=value;
                    }
                }
                if (currentTime>=timeChangingSongs) {
                    finished=true;
                }
                yield return null;
            }
        }
    }
}
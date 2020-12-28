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
        public AudioSource asSFX;

        public AudioSource music;
        private int lastChangedMusic;
        
        public AudioClip[] correctSound;
        public AudioClip[] failSound;
        public AudioClip[] menuSound;

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
            ChangeSongLevel(startingSongLevel);
        }

        public void PlayCorrect() {
            asSFX.PlayOneShot(correctSound[(int)Random.Range(0, correctSound.Length)]);
        }
        public void PlayWrong() {
            asSFX.PlayOneShot(failSound[(int)Random.Range(0, failSound.Length)]);
        }

        public void PlayMenuSound() {
            asSFX.PlayOneShot(menuSound[(int)Random.Range(0, menuSound.Length)]);
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
                        if(lastChangedMusic!=songNum) {
                            audiosources[x].volume=value;
                        }
                    }
                }
                if (currentTime>=timeChangingSongs) {
                    finished=true;
                }
                yield return null;
            }
        lastChangedMusic=songNum;
        }
    }
}
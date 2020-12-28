using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

namespace NamaeNashi {
    public class NNTextColorChangerBySong : MonoBehaviour{
        private float clipSize;
        private float extraTime;
        private Color originalColor;

        public float clipBegin;
        public float clipStop;
        public int numColorChanges;

        public AudioClip music;
        public Text text;

        private void Start() {
            clipSize=music.length;
            extraTime=clipSize-(clipStop-clipBegin);
            originalColor=text.color;
            StartCoroutine(ColoredMusic());
        }

        private IEnumerator ColoredMusic() {
            yield return new WaitForSeconds(clipBegin);
            while (true) {
                Debug.Log("Waiting for "+clipBegin);
                for (int x=0;x<numColorChanges-1;++x){
                    text.DOColor(GetRandomColor(),((clipStop-clipBegin)/numColorChanges));
                    Debug.Log("Waiting for "+(clipStop-clipBegin)/numColorChanges);
                    yield return new WaitForSeconds((clipStop-clipBegin)/numColorChanges);
                }
                text.DOColor(originalColor, ((clipStop-clipBegin)/numColorChanges));
                Debug.Log("Waiting for "+(clipStop-clipBegin)/numColorChanges);
                yield return new WaitForSeconds((clipStop-clipBegin)/numColorChanges);
                Debug.Log("Waiting for "+extraTime);
                yield return new WaitForSeconds(extraTime);
            }
        }

        private Color GetRandomColor(){
            float temp0 = Random.Range(0f, 1f);
            float temp1 = Random.Range(0f, 1f);
            float temp2 = Random.Range(0f, 1f);
            Color tempColor=new Color(temp0, temp1, temp2, 1f);
            return tempColor;
        }
    }
}

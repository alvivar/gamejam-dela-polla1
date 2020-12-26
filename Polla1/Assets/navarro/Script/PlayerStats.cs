using UnityEngine;
using System.Collections;

namespace navarro
{
    public class PlayerStats : MonoBehaviour
    {

        public int life = 100;
        public int power = 20;
        public string deadlevel;

        void Start()
        {
            StartCoroutine(Regenarator());
        }

        void Update()
        {
            if (life <= 0)
            {
                Application.LoadLevel(deadlevel);
            }
        }

        private IEnumerator Regenarator()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.7f);
                if (power < 100)
                {
                    power++;
                }
            }
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace navarro
{
    public class JP_DamagePlayer : MonoBehaviour
    {
        public float attackPause;
        private JP_PlayerStats stats;
        public JP_EnemyZombie zombie;
        private bool triggered = false;
        public Text textFiled;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!triggered && other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
            {
                triggered = true;
                stats = other.gameObject.GetComponent<JP_PlayerStats>() as JP_PlayerStats;
                stats.life -= 10;

                textFiled.text = "Zombie hits " + other.gameObject.name + "  \n" + textFiled.text;

                textFiled.text = other.gameObject.name + " HP Decreased to  " + stats.life + " \n" + textFiled.text;

                zombie.active = false;
                StartCoroutine(PauseZombie());
            }
        }

        private IEnumerator PauseZombie()
        {
            textFiled.text = "Zombie tired, waits " + attackPause + " seconds \n" + textFiled.text;

            yield return new WaitForSeconds(attackPause);
            zombie.active = true;
            triggered = false;
        }
    }

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace navarro
{
    public class JP_ZombieHit : MonoBehaviour
    {

        private JP_EnemyZombie zombie;
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
            if (other.gameObject.tag == "EnemyZombie")
            {
                textFiled.text = "Zombie was hit" + "  \n" + textFiled.text;
                zombie = other.gameObject.GetComponent<JP_EnemyZombie>() as JP_EnemyZombie;
                zombie.life -= 30;

            }
        }
    }

}

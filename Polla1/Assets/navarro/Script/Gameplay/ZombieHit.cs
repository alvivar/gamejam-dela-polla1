using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace navarro
{
    public class ZombieHit : MonoBehaviour
    {

        private EnemyZombie zombie;
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
                zombie = other.gameObject.GetComponent<EnemyZombie>() as EnemyZombie;
                zombie.life -= 30;

            }
        }
    }

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace navarro
{
    public class EnemyZombie : MonoBehaviour
    {
        public GameObject[] spawnPonits;
        public GameObject diamond;
        public bool active;
        public int life = 100;
        public float min = 5f;
        public float max = 15f;

        public GameObject[] targets;
        public Rigidbody2D rigid;

        // Animation purposes
        public Animator animator;

        private Vector3 Enemy;

        // The speed of the enemy
        public float speed = 30f;
        public GameObject bloodstain;

        // Store the movement
        private Vector2 movement;
        private float horizontal;
        private float vertical;
        public Text textFiled;

        // Use this for initialization
        void Start()
        {

        }

        private IEnumerator RestoreZombie()
        {
            yield return new WaitForSeconds(Random.Range(min, max));
            this.transform.position = spawnPonits[(int)Random.Range(0, spawnPonits.Length)].transform.position;
            life = 100;
            speed++;
            speed++;
            speed++;
            active = true;
        }

        void Update()
        {
            if (active && life < 0)
            {
                active = false;
                textFiled.text = "Zombie Dead" + "  \n" + textFiled.text;

                Instantiate(bloodstain, transform.position, Quaternion.identity);

                if (Random.Range(0, 10) > 5f)
                {
                    Debug.Log("Zombie Drops Diamond");
                    textFiled.text = "Zombie Drops Diamond" + "  \n" + textFiled.text;
                    Instantiate(diamond, transform.position + (Vector3.up * 15), Quaternion.identity);
                }

                this.transform.Translate(Vector3.up * -9900);
                StartCoroutine(RestoreZombie());
            }

            if (active && life > 0)
            {

                if (Vector3.Distance(this.transform.position, targets[0].transform.position) <
                    Vector3.Distance(this.transform.position, targets[1].transform.position))
                {
                    // Retrieve axis information
                    horizontal = targets[0].transform.position.x - transform.position.x;
                    vertical = targets[0].transform.position.y - transform.position.y;
                }
                else
                {
                    // Retrieve axis information
                    horizontal = targets[1].transform.position.x - transform.position.x;
                    vertical = targets[1].transform.position.y - transform.position.y;
                }


                // Movement per direction
                movement = new Vector2(horizontal, vertical);
                movement = movement.normalized;

                rigid.velocity = movement * speed;
            }
        }
    }
}

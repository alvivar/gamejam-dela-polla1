using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace navarro
{
    public class AuraManager : MonoBehaviour
    {

        public PlayerStats bride;
        private PlayerStats groom;
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
            if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
            {
                groom = other.gameObject.GetComponent<PlayerStats>() as PlayerStats;
                groom.life += 17;
                bride.life += 17;
                textFiled.text = "Wife heals " + other.gameObject.name + "  \n" + textFiled.text;
                textFiled.text = "Groom's HP: " + groom.life + "  \n" + textFiled.text;
                textFiled.text = "Wife's HP: " + bride.life + "  \n" + textFiled.text;
            }
        }
    }
}


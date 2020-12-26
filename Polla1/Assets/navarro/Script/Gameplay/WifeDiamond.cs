using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace navarro
{
    public class WifeDiamond : MonoBehaviour
    {

        public Text textFiled;

        void Awake()
        {
            textFiled = GameObject.Find("LogText").GetComponent<Text>() as Text;
        }

        private PlayerStats bride;
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
            if (other.gameObject.tag == "Player1")
            {
                bride = other.gameObject.GetComponent<PlayerStats>() as PlayerStats;
                bride.power += 50;
                textFiled.text = "Wife gets pet rock (Love Hability Increased)" + "  \n" + textFiled.text;
                Destroy(this.gameObject);
            }
        }
    }

}

using UnityEngine;
using System.Collections;

namespace navarro
{
    public class JP_MidPointPos : MonoBehaviour
    {
        public GameObject object1;
        public GameObject object2;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            this.transform.position = 0.5f * (object1.transform.position + object2.transform.position);
        }
    }

}

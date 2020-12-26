using UnityEngine;
using System.Collections;

namespace navarro
{
    public class FireBall : AbstractBehavior
    {
        public FireMover[] bullets;
        private int index = 0;
        private Vector3 dir;



        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            var shoot = inputState.GetButtonValue(inputButtons[0]);

            if (shoot && inputState.GetButtonHoldTime(inputButtons[0]) == 0)
            {

                switch (inputState.lastInputDir)
                {
                    case 0: dir = Vector3.right; break;
                    case 1: dir = Vector3.left; break;
                    case 2: dir = Vector3.up; break;
                    case 3: dir = Vector3.down; break;
                }

                bullets[index].FireBall(this.transform.position, dir);
                index++;

                if (index > (bullets.Length - 1)) index = 0;
            }
        }
    }
}

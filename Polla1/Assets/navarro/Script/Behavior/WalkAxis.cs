using UnityEngine;
using System.Collections;

namespace navarro
{
    public class WalkAxis : AbstractBehavior
    {

        public float speed = 50f;
        public float runMultiplier = 2f;
        public bool running;

        private int _dir;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            running = false;

            var right = inputState.GetButtonValue(inputButtons[0]);
            var left = inputState.GetButtonValue(inputButtons[1]);
            var up = inputState.GetButtonValue(inputButtons[3]);
            var down = inputState.GetButtonValue(inputButtons[4]);
            var run = inputState.GetButtonValue(inputButtons[2]);

            if (right || left)
            {
                var tmpSpeed = speed;

                if (right) { inputState.lastInputDir = 0; }
                else if (left) { inputState.lastInputDir = 1; }

                if (run && runMultiplier > 0)
                {
                    tmpSpeed *= runMultiplier;
                    running = true;
                }

                var velX = tmpSpeed * (float)inputState.directionH;

                body2d.velocity = new Vector2(velX, body2d.velocity.y);
            }

            if (up || down)
            {
                var tmpSpeed = speed;

                if (up) { inputState.lastInputDir = 2; }
                else if (down) { inputState.lastInputDir = 3; }

                if (run && runMultiplier > 0)
                {
                    tmpSpeed *= runMultiplier;
                    running = true;
                }

                var velY = tmpSpeed * (float)inputState.directionV;

                body2d.velocity = new Vector2(body2d.velocity.x, velY);
            }
        }
    }
}


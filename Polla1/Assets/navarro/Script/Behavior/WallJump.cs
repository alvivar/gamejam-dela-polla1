using UnityEngine;
using System.Collections;

namespace navarro
{
	public class WallJump : AbstractBehavior
	{

		public Vector2 jumpVelocity = new Vector2(50, 200);
		public bool jumpigOffWall;

		public float resetDelay = 0.2f;

		private float timeEnlased = 0f;

		// Update is called once per frame
		void Update()
		{
			if (collisionState.onWall && !collisionState.standing)
			{
				var canJump = inputState.GetButtonValue(inputButtons[0]);

				if (canJump && !jumpigOffWall)
				{
					inputState.directionH = (inputState.directionH == Directions.Right) ? Directions.Left : Directions.Right;
					body2d.velocity = new Vector2(jumpVelocity.x * (float)inputState.directionH, jumpVelocity.y);

					ToggleScripts(false);
					jumpigOffWall = true;
				}
			}

			if (jumpigOffWall)
			{
				timeEnlased += Time.deltaTime;

				if (timeEnlased > resetDelay)
				{
					ToggleScripts(true);
					jumpigOffWall = false;
					timeEnlased = 0f;
				}
			}
		}
	}
}

using UnityEngine;
using System.Collections;

namespace navarro
{
	public class LongJump : Jump
	{

		public float longJumpDelay = 0.15f;
		public float longJumpMultiplier = 1.5f;
		public bool canLongJump;
		public bool isLongJumping;

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		protected override void Update()
		{

			var canJump = inputState.GetButtonValue(inputButtons[0]);
			var holdTime = inputState.GetButtonHoldTime(inputButtons[0]);

			if (!canJump)
				canLongJump = false;

			if (collisionState.standing && isLongJumping)
				canLongJump = false;

			base.Update();

			if (canLongJump && !collisionState.standing && holdTime > longJumpDelay)
			{
				var vel = body2d.velocity;
				body2d.velocity = new Vector3(vel.x, jumpSpeed * longJumpMultiplier);
				canLongJump = false;
				isLongJumping = true;
			}
		}

		protected override void OnJump()
		{
			base.OnJump();
			canLongJump = true;
		}
	}
}

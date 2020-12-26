using UnityEngine;
using System.Collections;

namespace navarro
{
	[RequireComponent(typeof(Rigidbody2D))]
	[RequireComponent(typeof(InputState))]

	public class JP_SimpleMovement : MonoBehaviour
	{

		public float speed = 5f;
		public JP_Buttons[] input;

		private Rigidbody2D _body2d;
		private InputState inputState;
		private float _var;

		// Use this for initialization
		void Start()
		{
			_body2d = this.gameObject.GetComponent<Rigidbody2D>();
			inputState = this.gameObject.GetComponent<InputState>();
		}

		// Update is called once per frame
		void Update()
		{

			var right = inputState.GetButtonValue(input[0]);
			var left = inputState.GetButtonValue(input[1]);
			var velX = speed;

			if (right || left)
			{
				velX *= left ? -1 : 1;
			}
			else
			{
				velX = 0f;
			}

			_body2d.velocity = new Vector2(velX, _body2d.velocity.y);
		}
	}
}

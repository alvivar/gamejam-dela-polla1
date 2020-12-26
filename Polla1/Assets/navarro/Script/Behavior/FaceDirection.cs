using UnityEngine;
using System.Collections;

namespace navarro
{
	public class FaceDirection : AbstractBehavior
	{

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			var right = inputState.GetButtonValue(inputButtons[0]);
			var left = inputState.GetButtonValue(inputButtons[1]);
			var up = inputState.GetButtonValue(inputButtons[2]);
			var down = inputState.GetButtonValue(inputButtons[3]);

			if (right)
			{
				inputState.directionH = Directions.Right;
			}
			else if (left)
			{
				inputState.directionH = Directions.Left;
			}

			if (up)
			{
				inputState.directionV = Directions.Right;
			}
			else if (down)
			{
				inputState.directionV = Directions.Down;
			}

			//transform.localScale = new Vector3 (transform.localScale.x * (float)inputState.directionH, transform.localScale.y , transform.localScale.z);
		}
	}
}


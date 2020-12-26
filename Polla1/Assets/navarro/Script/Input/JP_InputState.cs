using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace navarro
{
	[RequireComponent(typeof(Rigidbody2D))]

	public class JP_ButtonState
	{
		public bool value;
		public float holdTime = 0f;
	}

	public enum JP_Directions
	{
		Right = 1,
		Left = -1,
		Up = 1,
		Down = -1
	}

	public class InputState : MonoBehaviour
	{

		public JP_Directions directionH = JP_Directions.Right;
		public JP_Directions directionV = JP_Directions.Down;
		public float absVelX = 0f;
		public float absVelY = 0f;

		private Rigidbody2D body2d;
		private Dictionary<JP_Buttons, JP_ButtonState> _buttonsStates = new Dictionary<JP_Buttons, JP_ButtonState>();
		public int lastInputDir = 3;

		void Awake()
		{
			body2d = GetComponent<Rigidbody2D>();
		}

		void FixedUpdate()
		{
			absVelX = Mathf.Abs(body2d.velocity.x);
			absVelY = Mathf.Abs(body2d.velocity.y);
		}

		public void SetButtonValue(JP_Buttons key, bool value)
		{
			if (!_buttonsStates.ContainsKey(key))
				_buttonsStates.Add(key, new JP_ButtonState());

			var state = _buttonsStates[key];

			if (state.value && !value)
			{
				state.holdTime = 0f;
			}
			else if (state.value && value)
			{
				state.holdTime += Time.deltaTime;
			}

			state.value = value;
		}

		public bool GetButtonValue(JP_Buttons key)
		{
			if (_buttonsStates.ContainsKey(key))
			{
				return _buttonsStates[key].value;
			}
			else
			{
				return false;
			}
		}

		public float GetButtonHoldTime(JP_Buttons key)
		{
			if (_buttonsStates.ContainsKey(key))
			{
				return _buttonsStates[key].holdTime;
			}
			else
			{
				return 0f;
			}
		}
	}

}

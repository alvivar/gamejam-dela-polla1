using UnityEngine;
using System.Collections;

namespace navarro
{
	public enum JP_Buttons
	{
		Right,
		Left,
		Up,
		Down,
		A,
		B
	}

	public enum JP_Condition
	{
		GreaterThan,
		LessThan
	}

	[System.Serializable]
	public class JP_InputAsixsState
	{
		public string axisName;
		public float offValue;
		public JP_Buttons button;
		public JP_Condition condition;

		public bool value
		{
			get
			{
				var val = Input.GetAxis(axisName);

				switch (condition)
				{
					case JP_Condition.GreaterThan:
						return val > offValue;
					case JP_Condition.LessThan:
						return val < offValue;
				}
				return false;
			}
		}
	}

	public class JP_CustomManager : MonoBehaviour
	{

		public JP_InputAsixsState[] inputs;
		public InputState inputState;
		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			foreach (JP_InputAsixsState input in inputs)
			{
				inputState.SetButtonValue(input.button, input.value);
			}
		}
	}
}

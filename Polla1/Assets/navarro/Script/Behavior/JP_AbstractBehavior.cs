using UnityEngine;
using System.Collections;

namespace navarro
{
	public abstract class JP_AbstractBehavior : MonoBehaviour
	{

		public JP_Buttons[] inputButtons;
		public MonoBehaviour[] dissableScripts;
		protected InputState inputState;
		protected Rigidbody2D body2d;
		protected JP_CollisionState collisionState;

		protected virtual void Awake()
		{
			inputState = GetComponent<InputState>();
			body2d = GetComponent<Rigidbody2D>();
			collisionState = GetComponent<JP_CollisionState>();
		}

		protected virtual void ToggleScripts(bool value)
		{
			foreach (var script in dissableScripts)
			{
				script.enabled = value;
			}
		}
	}
}

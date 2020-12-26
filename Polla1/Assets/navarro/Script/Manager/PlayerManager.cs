using UnityEngine;
using System.Collections;

namespace navarro
{
	[RequireComponent(typeof(InputState))]
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(FaceDirection))]


	public class PlayerManager : MonoBehaviour
	{

		public float threshold;
		private InputState inputState;
		private Animator animator;

		void Awake()
		{
			inputState = GetComponent<InputState>();
			animator = GetComponent<Animator>();
		}

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{


			if (inputState.absVelX <= threshold && inputState.absVelY <= threshold)
			{
				ChangeAnimation(0, inputState.lastInputDir);
			}

			if (inputState.absVelX > threshold)
			{
				ChangeAnimation(1, inputState.lastInputDir);
			}

			if (inputState.absVelY > threshold)
			{
				ChangeAnimation(1, inputState.lastInputDir);
			}
		}

		void ChangeAnimation(int value, int direcction)
		{
			animator.SetInteger("AnimState", value);
			animator.SetInteger("AnimDirection", direcction);
		}
	}
}

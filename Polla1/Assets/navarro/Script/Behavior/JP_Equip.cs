using UnityEngine;
using System.Collections;

namespace navarro
{
	[RequireComponent(typeof(Animator))]

	public class JP_Equip : JP_AbstractBehavior
	{

		private int _currentItem;
		private Animator animator;

		public int currentItem
		{
			get { return _currentItem; }

			set
			{
				_currentItem = value;
				animator.SetInteger("EquippedItem", _currentItem);
			}
		}

		protected override void Awake()
		{
			base.Awake();
			animator = GetComponent<Animator>();
		}
	}
}

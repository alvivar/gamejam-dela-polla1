using UnityEngine;
using System.Collections;

namespace navarro
{
	public class JP_PowerUpFlower : JP_Collectable
	{

		public int itemID = 1;

		override protected void OnCollect(GameObject target)
		{

			var equitedBehavior = target.GetComponent<JP_Equip>();
			if (equitedBehavior != null)
			{
				equitedBehavior.currentItem = itemID;
			}
		}
	}
}


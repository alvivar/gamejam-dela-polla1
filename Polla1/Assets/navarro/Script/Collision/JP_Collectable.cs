using UnityEngine;
using System.Collections;

namespace navarro
{
	public class JP_Collectable : MonoBehaviour
	{

		public string targetTag = "Player";

		void OnTriggerEnter2D(Collider2D target)
		{
			if (target.gameObject.tag == targetTag)
			{
				OnCollect(target.gameObject);
				OnDestroy();
			}
		}

		protected virtual void OnCollect(GameObject target)
		{

		}

		protected virtual void OnDestroy()
		{
			Destroy(gameObject);
		}
	}

}
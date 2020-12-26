using UnityEngine;
using System.Collections;

namespace navarro
{
	public class JP_DustEffect : MonoBehaviour
	{

		void OnDestroy()
		{
			Destroy(gameObject);
		}
	}
}

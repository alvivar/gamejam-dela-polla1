using UnityEngine;
using System.Collections;

namespace navarro
{
	public class DustEffect : MonoBehaviour
	{

		void OnDestroy()
		{
			Destroy(gameObject);
		}
	}
}

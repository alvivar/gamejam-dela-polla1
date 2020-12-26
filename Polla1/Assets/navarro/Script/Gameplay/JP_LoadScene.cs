using UnityEngine;
using System.Collections;

namespace navarro
{
	public class JP_LoadScene : MonoBehaviour
	{

		public string levelname;
		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetKeyDown("space"))
				Application.LoadLevel(levelname);
		}
	}
}

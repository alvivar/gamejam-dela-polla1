using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class RayMainSound {

	public string name;
	[Header("TAG MUST ALREADY EXIST")]
	public string tag;


	[Space]
	public AudioClip clip;
	[Space]
	public float volume = 1f;
	public float pitch = 1f;
	[Space]
	public AudioSource source;
	public AudioMixerGroup mixer;
	[Space]
	public bool playThroughScenes;
	public bool playOnAwake;
	public bool loop;

}

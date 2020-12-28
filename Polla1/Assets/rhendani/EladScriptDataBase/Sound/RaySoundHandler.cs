using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RaySoundHandler : MonoBehaviour
{

	[ShowInfo("RAY SOUND HANDLER")]


	public List<RaySoundList> sets = new List<RaySoundList>();

	List<RayMainSound> allSounds = new List<RayMainSound>();

	RaySoundHandler[] sounds;

	private void Awake()
    {
		OnLevelWasLoaded();
    }

    void OnLevelWasLoaded()
	{


		sounds = FindObjectsOfType<RaySoundHandler>();
		DontDestroyOnLoad(sounds[0]);
		if (sounds.Length > 1) Destroy(sounds[1].gameObject);


		foreach (RaySoundList l in sets)
		{

			foreach (RayMainSound s in l.sounds)
			{
				// PLAY ON AWAKE


				if (s.name == "")
				{
					s.name = s.clip.name;
				}

				//if (s.playThroughScenes)
                //{
				//	Destroy(s.source.gameObject);
                //}

				allSounds.Add(s);
				SpawnSound(s, false);


			}

		}

	}


	private void Reset()
	{
		// SET DEFAULT VALUES
		RayMainSound sound = new RayMainSound();
		sound.name = "default sound";
		sound.volume = 1;
		sound.pitch = 1;

		RaySoundList set = new RaySoundList();
		set.setName = "default set";
		set.sounds.Add(sound);

		sets.Add(set);
	}


	void SpawnSound(RayMainSound s, bool forced)
	{
		if (s.source == null)
		{
			DefaultMode(s);
		}
		else
		{
			OverWriteMode(s, forced);
		}
	}


	void DefaultMode(RayMainSound s)
	{
		AudioSource[] check = FindObjectsOfType<AudioSource>();
		bool activation = true;

        for (int i = 0; i < check.Length; i++)
        {

			if (check[i].name == s.name)
            {
				activation = false;
            }

        }

		if (!activation) return;

		write.c("running");

		GameObject obj = new GameObject();
		AudioSource newSound = obj.AddComponent<AudioSource>();

		if (s.name.Count() > 0) newSound.name = s.name;
		else
		{
			// RENAME SOUND TO NUMBER SOUND
			newSound.name = s.clip.name;
		}

		s.source = newSound;

		if (s.tag != "") newSound.tag = s.tag;

		newSound.outputAudioMixerGroup = s.mixer;
		newSound.clip = s.clip;
		newSound.loop = s.loop;
		newSound.playOnAwake = s.playOnAwake;
		newSound.volume = s.volume;
		newSound.pitch = s.pitch;

		if (s.playThroughScenes) DontDestroyOnLoad(newSound);
		if (s.playOnAwake) newSound.Play();

	}

	void OverWriteMode(RayMainSound s, bool forced)
	{
		s.source.outputAudioMixerGroup = s.mixer;
		s.source.clip = s.clip;
		s.source.loop = s.loop;
		s.source.volume = s.volume;
		s.source.pitch = s.pitch;

		if (forced) s.source.Play();
		else if(!s.source.isPlaying && s.playOnAwake) s.source.Play();

	}

	// PLAY RANDOM
	public void RandomPlay(string setName)
	{
		foreach (RaySoundList s in sets)
		{
			if (s.setName == setName)
			{
				int ran = Random.Range(0, s.sounds.Count);

				PlaySound(s.sounds[ran].name);
			}
		}
	}

	// PLAY COMMAND
	public void PlaySound(string soundName)
	{
		foreach (RayMainSound s in allSounds)
		{
			if (s.name == soundName)
			{
				SpawnSound(s, true);
			}
		}
	}


	// SET VOLUME SOUND
	public void SetVolume(string soundName, float volume)
	{
		foreach (RayMainSound s in allSounds)
		{
			if (s.name == soundName)
			{
				s.volume = volume;
			}
		}
	}


	// STOP COMMAND
	public void StopSound(string name)
	{

		foreach (AudioSource g in FindObjectsOfType<AudioSource>())
		{
			if (g.transform.name == name)
			{
				Destroy(g.gameObject);
			}
		}
	}

	// STOP COMMAND
	public void StopSoundGroup(string groupName)
	{
		foreach (RaySoundList s in sets)
		{
			if (s.setName == groupName)
			{
				foreach (RayMainSound m in s.sounds)
				{
					m.source.Stop();
				}
			}
		}
	}

	// SET VOLUME COMMAND
	public void SetVolumeInside(string name, float volume)
	{
		foreach (RayMainSound s in allSounds)
		{
			if (s.name == name)
			{
				s.volume = volume;
			}
		}
	}

	// check out if works
	// SET VOLUME OF SOUNDS
	public void SetVolumeAll(string name, float volume)
	{
		// 1
		foreach (RayMainSound s in allSounds)
		{
			if (s.name == name)
			{
				s.volume = volume;
			}
		}

		// 2
		AudioSource[] getSounds = FindObjectsOfType<AudioSource>();
		foreach (AudioSource aud in getSounds)
		{
			if (aud.tag == tag && aud.name == name)
			{
				aud.volume = volume;

			}
		}
	}

	// SET VOLUME COMMAND
	public void SetVolumeOfTag(string name, float volume, string tag)
	{
		AudioSource[] getSounds = FindObjectsOfType<AudioSource>();
		foreach (AudioSource aud in getSounds)
		{
			if (aud.tag == tag && aud.name == name)
			{
				aud.volume = volume;

			}
		}
	}

	// SET PITCH COMMAND
	public void SetPitch(string name, float pitch)
	{
		foreach (RayMainSound s in allSounds)
		{
			if (s.name == name)
			{
				s.pitch = pitch;
			}
		}
	}

	// CLEAN SOUNDS
	public void CleanSoundsOfTag(int maxAmmount, string tag)
	{
		if (GameObject.FindGameObjectsWithTag(tag) != null)
		{
			GameObject[] cleanSounds = GameObject.FindGameObjectsWithTag(tag);
			if (cleanSounds.Length > maxAmmount)
			{
				foreach (GameObject aud in cleanSounds)
				{
					Destroy(aud);
				}
			}
		}
	}


	// SET ALL THE VALUES OF A GROUP
	public void SetVolumeOfGroup(string setName, float set)
	{
		foreach (RaySoundList s in sets)
		{
			if (s.setName == setName)
			{
				foreach (RayMainSound m in s.sounds)
				{
					m.volume = set;
					m.source.volume = set;
				}
			}
		}
	}


	public void SetPitchOfGroup(string setName, float set)
	{
		foreach (RaySoundList s in sets)
		{
			if (s.setName == setName)
			{
				foreach (RayMainSound m in s.sounds)
				{
					m.pitch = set;
					m.source.pitch = set;
				}
			}
		}
	}

	public void SetLoopGroup(string setName, bool set)
	{
		foreach (RaySoundList s in sets)
		{
			if (s.setName == setName)
			{
				foreach (RayMainSound m in s.sounds)
				{
					m.loop = set;
					m.source.loop = set;
				}
			}
		}
	}

}
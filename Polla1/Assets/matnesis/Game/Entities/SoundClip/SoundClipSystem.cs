using UnityEngine;

public class SoundClipSystem : MonoBehaviour
{
    public AudioClip thunder;

    public enum SoundName { Thunder }

    void Update()
    {
        var soundClips = EntitySet.SoundClips;
        for (int i = 0; i < soundClips.Length; i++)
        {
            var soundClip = soundClips.Elements[i];

            if (soundClip.once)
            {
                soundClip.once = false;
                soundClip.source.PlayOneShot(GetClip(soundClip.clip));
            }
        }
    }

    AudioClip GetClip(SoundName name)
    {
        if (name == SoundName.Thunder)
            return thunder;

        return null;
    }
}
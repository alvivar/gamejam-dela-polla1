using UnityEngine;

public class SoundClipSystem : MonoBehaviour
{
    public AudioClip thunderClip;
    public AudioClip knockClip;

    public enum SoundName
    {
        Thunder,
        Knock
    }

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
            return thunderClip;

        else if (name == SoundName.Knock)
            return knockClip;

        return null;
    }
}
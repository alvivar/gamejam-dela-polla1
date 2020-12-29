using UnityEngine;

// !Gigas
public class SoundClip : MonoBehaviour
{
    public bool once = false;

    [Header("Config")]
    public string id;
    public SoundClipSystem.SoundName clip;

    [Header("Required Children")]
    public AudioSource source;

    private void OnEnable()
    {
        EntitySet.AddSoundClip(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveSoundClip(this);
    }
}
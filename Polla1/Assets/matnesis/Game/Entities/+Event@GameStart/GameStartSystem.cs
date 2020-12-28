using UnityEngine;

public class GameStartSystem : MonoBehaviour
{
    [Header("Internal")]
    public bool ready = false;
    public MainMessage mainMessage;

    bool skipIntro = true;

    void Start()
    {
        this.tt("Intro")
            .Reset()
            .Wait(() => ready)
            .Add(1, () =>
            {
                mainMessage = EntitySet.MainMessages.Elements[0];
                mainMessage.main.text = Texts.INTRO;
                mainMessage.mainDamp = 10f;
                mainMessage.showMain = true;
            })
            .Add(!skipIntro ? 6 : 1, () =>
            {
                mainMessage.mainDamp = 0.1f;
                mainMessage.showMain = false;
                mainMessage.main.text = "";
            })
            .Add(1, () =>
            {
                // this.tt("FadingMemories").Play();
            });

        var index = 0;
        this.tt("FadingMemories")
            .Reset()
            .Pause()
            .Add(() => Random.Range(1f, 2f), t =>
            {
                var memory = Texts.FADING_MEMORIES[index++];
                mainMessage.main.text = memory;

                if (index >= Texts.FADING_MEMORIES.Length)
                    t.self.Stop();
            })
            .Repeat();

    }

    void Update()
    {
        ready = true;
    }
}
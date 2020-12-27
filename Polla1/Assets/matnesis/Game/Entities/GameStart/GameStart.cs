using UnityEngine;

public class GameStart : MonoBehaviour
{
    public bool ready = false;
    public MainMessage mainMessage;

    void Start()
    {
        this.tt("Intro")
            .Reset()
            .Wait(() => ready)
            .Add(1, () =>
            {
                mainMessage = EntitySet.MainMessages.Elements[0];
                mainMessage.mainText.text = Texts.INTRO;
                mainMessage.damp = 10f;
                mainMessage.show = true;
            })
            .Add(6, () =>
            {
                mainMessage.damp = 0.1f;
                mainMessage.show = false;
                mainMessage.mainText.text = "";
            })
            .Add(1, () =>
            {
                this.tt("FadingMemories").Play();
            });

        var index = 0;
        this.tt("FadingMemories")
            .Reset()
            .Pause()
            .Add(() => Random.Range(1f, 2f), t =>
            {
                var memory = Texts.FADING_MEMORIES[index++];
                mainMessage.mainText.text = memory;

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
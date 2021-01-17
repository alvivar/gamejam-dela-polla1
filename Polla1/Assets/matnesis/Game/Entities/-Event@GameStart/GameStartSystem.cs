using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartSystem : MonoBehaviour
{
    [Header("Internal")]
    public bool ready = false;
    public MainMessage mainMessage;

    bool skipIntro = true;

    void Start()
    {
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
                .Add(!skipIntro ? 5 : 1, () =>
                {
                    mainMessage.mainDamp = 0.1f;
                    mainMessage.showMain = false;
                    mainMessage.main.text = "";
                })
                .Add(1, () =>
                {
                    // I don't think I need this intro?
                    // this.tt("FadingMemories").Play();
                    // this.tt("NotYet").Play();
                });
        }

        {
            var index = 0;
            this.tt("FadingMemories")
                .Reset()
                .Pause()
                .Wait(() => ready)
                .Add(() => Random.Range(1f, 2f), t =>
                {
                    var memory = Texts.FADING_MEMORIES[index++];
                    mainMessage.main.text = memory;

                    if (index >= Texts.FADING_MEMORIES.Length)
                        t.self.Stop();
                })
                .Repeat();
        }

        {
            this.tt("NotYet")
                .Reset()
                .Pause()
                .Wait(() => ready)
                .Add(10, () =>
                {
                    mainMessage.main.text = "";
                    mainMessage.main.text += "\t\tBUT...\n\n";
                    mainMessage.mainDamp = 10f;
                    mainMessage.showMain = true;
                })
                .Add(2, () =>
                {
                    mainMessage.main.text += "\t\tThe game isn't ready yet.\n";
                })
                .Add(2, () =>
                {
                    mainMessage.main.text += "\t\tIt needs more time!\n\n";
                    mainMessage.mainDamp = 10f;
                    mainMessage.showMain = true;
                })
                .Add(3, () =>
                {
                    Application.OpenURL("https://forms.gle/3HanE53EM1m6hRJJA");
                    SceneManager.LoadScene(0);
                });
        }
    }

    void Update()
    {
        ready = true;

        // if (Input.GetKeyDown(KeyCode.Escape))
        // {
        //     this.tt("TheEnd").Add(() =>
        //         {
        //             mainMessage.main.text = Texts.EXIT_GAME;
        //             mainMessage.mainDamp = 10f;
        //             mainMessage.showMain = true;
        //         })
        //         .Add(2, () =>
        //         {
        //             SceneManager.LoadScene(0);
        //         });
        // }
    }
}
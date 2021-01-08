using UnityEngine;

public class VoidDetectionSystem : MonoBehaviour
{
    bool intoTheVoid = false;
    bool atLeastOneVoid = false;

    MainMessage mainMessage;

    void Update()
    {
        if (!mainMessage)
            mainMessage = EntitySet.MainMessages.Elements[0];

        var voidDetections = EntitySet.VoidPlayers;
        for (int i = 0; i < voidDetections.Length; i++)
        {
            var voidDetection = voidDetections.Elements[i];

            if (intoTheVoid)
                continue;

            if (voidDetection.transform.position.y <= -200)
            {
                intoTheVoid = true;
                atLeastOneVoid = true;

                mainMessage.mainDamp = 1;
                mainMessage.main.text = "";
                mainMessage.showMain = true;

                this.tt("IntoTheVoid")
                    .Reset()
                    .Add(3, t =>
                    {
                        mainMessage.main.text = "";
                        mainMessage.main.text += "\t\tThe void rejects you";
                    })
                    .Add(3, () =>
                    {
                        mainMessage.main.text = "";
                        mainMessage.main.text += "\t\tThe void rejects you\n\n\t\t\tYou remembered the time\n\t\t\twhen you wanted something and failed";
                    })
                    .Add(3, () =>
                    {
                        voidDetection.fps.enabled = false;
                        voidDetection.transform.position = new Vector3(0, 100, 0);
                    })
                    .Add(1, () =>
                    {
                        intoTheVoid = false;

                        voidDetection.fps.enabled = true;
                        mainMessage.mainDamp = 1;
                        mainMessage.showMain = false;
                    });
            }
        }
    }
}
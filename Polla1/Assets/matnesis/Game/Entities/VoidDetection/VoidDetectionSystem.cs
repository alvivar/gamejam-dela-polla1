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

        var voidDetections = EntitySet.VoidDetections;
        for (int i = 0; i < voidDetections.Length; i++)
        {
            var voidDetection = voidDetections.Elements[i];

            if (intoTheVoid)
                return;

            if (voidDetection.transform.position.y <= -200)
            {
                intoTheVoid = true;
                atLeastOneVoid = true;

                mainMessage.damp = 3;
                mainMessage.mainText.text = "";
                mainMessage.show = true;

                this.tt("IntoTheVoid")
                    .Reset()
                    .Add(3, t =>
                    {
                        mainMessage.mainText.text = Texts.VOID_REJECTS_YOU[0];
                    })
                    .Add(2, () =>
                    {
                        mainMessage.mainText.text = Texts.VOID_REJECTS_YOU[1];
                    })
                    .Add(3, () =>
                    {
                        mainMessage.mainText.text = Texts.VOID_REJECTS_YOU[2];
                    })
                    .Add(3, () =>
                    {
                        voidDetection.fps.enabled = false;
                        voidDetection.transform.position = new Vector3(0, 100, 0);

                        mainMessage.mainText.text = Texts.VOID_REJECTS_YOU[3];
                    })
                    .Add(1, () =>
                    {
                        intoTheVoid = false;

                        voidDetection.fps.enabled = true;

                        mainMessage.damp = 1;
                        mainMessage.show = false;
                    });
            }
        }
    }
}
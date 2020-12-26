using UnityEngine;

public class VoidDetectionSystem : MonoBehaviour
{
    bool intoTheVoid = false;
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
                mainMessage.damp = 3;
                mainMessage.mainText.text = "";
                mainMessage.show = true;

                this.tt("IntoTheVoid")
                    .Reset()
                    .Add(3, () =>
                    {
                        mainMessage.mainText.text = Texts.VOID_REJECTS_YOU[0];
                    });
            }
        }
    }
}
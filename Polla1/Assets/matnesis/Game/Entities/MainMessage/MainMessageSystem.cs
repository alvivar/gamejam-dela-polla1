using UnityEngine;

public class MainMessageSystem : MonoBehaviour
{
    void Update()
    {
        var mainMessages = EntitySet.MainMessages;
        for (int i = 0; i < mainMessages.Length; i++)
        {
            var mainMessage = mainMessages.Elements[i];

            if (mainMessage.show)
            {
                mainMessage.background.color = Color.Lerp(mainMessage.background.color, Colorf.ColorAlpha(Color.black, 1), Time.deltaTime * mainMessage.damp);
                mainMessage.main.color = Color.Lerp(mainMessage.main.color, Colorf.ColorAlpha(Color.white, 1), Time.deltaTime * mainMessage.damp);
            }
            else
            {
                mainMessage.background.color = Color.Lerp(mainMessage.background.color, Colorf.ColorAlpha(mainMessage.background.color, 0), Time.deltaTime * mainMessage.damp);
                mainMessage.main.color = Color.Lerp(mainMessage.main.color, Colorf.ColorAlpha(mainMessage.main.color, 0), Time.deltaTime * mainMessage.damp);
            }
        }
    }
}
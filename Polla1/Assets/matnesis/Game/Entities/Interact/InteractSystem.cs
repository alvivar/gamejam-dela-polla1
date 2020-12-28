using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    void Update()
    {
        var interacts = EntitySet.Interacts;
        for (int i = 0; i < interacts.Length; i++)
        {
            var interact = interacts.Elements[i];

            if (interact.show)
            {
                interact.background.color = Color.Lerp(interact.background.color, Color.black, Time.deltaTime * interact.damp);
                interact.content.color = Color.Lerp(interact.content.color, Color.white, Time.deltaTime * interact.damp);
            }
            else
            {
                interact.background.color = Color.Lerp(interact.background.color, Colorf.ColorAlpha(interact.background.color, 0), Time.deltaTime * interact.damp);
                interact.content.color = Color.Lerp(interact.content.color, Colorf.ColorAlpha(interact.content.color, 0), Time.deltaTime * interact.damp);
            }
        }
    }
}
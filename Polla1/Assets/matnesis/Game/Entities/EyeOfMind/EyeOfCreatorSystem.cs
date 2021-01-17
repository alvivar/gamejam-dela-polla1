using UnityEngine;

public class EyeOfCreatorSystem : MonoBehaviour
{
    void Update()
    {
        var eyeOfCreators = EntitySet.EyeOfCreators;
        for (int i = 0; i < eyeOfCreators.Length; i++)
        {
            var eyeOfCreator = eyeOfCreators.Elements[i];

            // Look for a free eye

            EyeOfMind chosen = null;
            var eyes = EntitySet.EyeOfMinds;
            for (int j = 0; j < eyes.Length; j++)
            {
                var eye = eyes.Elements[j];

                if (eye.state == EyeOfMind.State.None)
                {
                    chosen = eye;
                    break;
                }

                if (eyeOfCreator.show)
                {
                    eye.content.color = Color.Lerp(eye.content.color, Color.white, Time.deltaTime);
                }
                else
                {
                    eye.content.color = Color.Lerp(eye.content.color, Colorf.ColorAlpha(eye.content.color, 0), Time.deltaTime);
                }
            }

            if (!chosen)
                continue;

            // Dispatch a new eye

            if (eyeOfCreator.queue.Length > 0)
            {
                var content = eyeOfCreator.queue.Elements[0];
                eyeOfCreator.queue.RemoveAt(0);

                for (int j = 0; j < eyes.Length; j++)
                {
                    var eye = eyes.Elements[j];
                    if (eye.content.text == content)
                    {
                        chosen = null;
                        break;
                    }
                }

                if (!chosen)
                    continue;

                chosen.content.text = content;
                chosen.state = EyeOfMind.State.EyeOfMind;
            }
        }
    }
}
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
            }

            if (!chosen)
                continue;

            // Dispatch a new eye

            if (eyeOfCreator.queue.Length > 0)
            {
                chosen.content.text = eyeOfCreator.queue.Elements[0];
                chosen.state = EyeOfMind.State.EyeOfMind;
                eyeOfCreator.queue.RemoveAt(0);
            }
        }
    }
}
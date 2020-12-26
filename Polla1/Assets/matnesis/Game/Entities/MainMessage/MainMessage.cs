using TMPro;
using UnityEngine;
using UnityEngine.UI;

// !Gigas
public class MainMessage : MonoBehaviour
{
    public bool show = false;
    public float damp = 3;

    [Header("Children References")]
    public Canvas canvas;
    public TextMeshProUGUI mainText;
    public Image background;

    private void OnEnable()
    {
        EntitySet.AddMainMessage(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveMainMessage(this);
    }
}
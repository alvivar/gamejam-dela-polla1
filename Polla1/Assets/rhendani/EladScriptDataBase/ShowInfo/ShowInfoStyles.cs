using UnityEngine;

public class ShowInfoStyles : MonoBehaviour
{

    public static Color ConfigColor(ShowInfoColor colors)
    {
        switch ((int)colors)
        {
            case 00: return new Color(1.00f, 1.00f, 1.00f);  // White
            case 01: return new Color(0.75f, 0.75f, 0.75f);  // GrayLight
            case 02: return new Color(0.50f, 0.50f, 0.50f);  // Gray
            case 03: return new Color(0.25f, 0.25f, 0.25f);  // GrayDark
            case 04: return new Color(0.00f, 0.00f, 0.00f);  // Black
            case 05: return new Color(0.60f, 0.60f, 0.50f);  // GrayCream
            case 06: return new Color(0.50f, 0.50f, 0.60f);  // GrayBlue
            case 07: return new Color(0.50f, 0.60f, 0.50f);  // GrayGreen
            case 08: return new Color(0.60f, 0.50f, 0.50f);  // GrayPink
            case 09: return new Color(0.00f, 0.00f, 1.00f);  // BlueFull
            case 10: return new Color(0.00f, 0.00f, 0.50f);  // BlueFull Dark
            case 11: return new Color(0.00f, 0.50f, 1.00f);  // BlueSky 
            case 12: return new Color(0.00f, 0.25f, 0.50f);  // BlueSky Dark
            case 13: return new Color(0.00f, 1.00f, 1.00f);  // Cyan
            case 14: return new Color(0.00f, 0.75f, 0.75f);  // Cyan Dark
            case 15: return new Color(0.00f, 1.00f, 0.75f);  // GreenWater
            case 16: return new Color(0.00f, 0.70f, 0.55f);  // GreenWater Dark
            case 17: return new Color(0.00f, 1.00f, 0.00f);  // GreenFull
            case 18: return new Color(0.00f, 0.50f, 0.00f);  // GreenFull Dark
            case 19: return new Color(0.50f, 1.00f, 0.00f);  // GreenLemon
            case 20: return new Color(0.25f, 0.50f, 0.00f);  // GreenLemon Dark
            case 21: return new Color(1.00f, 1.00f, 0.00f);  // Yellow
            case 22: return new Color(0.50f, 0.50f, 0.00f);  // Yellow Dark
            case 23: return new Color(1.00f, 0.50f, 0.00f);  // Orange
            case 24: return new Color(0.50f, 0.25f, 0.00f);  // Orange Dark
            case 25: return new Color(0.60f, 0.45f, 0.30f);  // Brown
            case 26: return new Color(0.30f, 0.22f, 0.15f);  // Brown Dark
            case 27: return new Color(1.00f, 0.00f, 0.00f);  // RedFull
            case 28: return new Color(0.50f, 0.00f, 0.00f);  // RedFull Dark
            case 29: return new Color(0.80f, 0.00f, 1.00f);  // Purple
            case 30: return new Color(0.40f, 0.00f, 0.50f);  // Purple Dark
            case 31: return new Color(1.00f, 0.00f, 1.00f);  // Magenta
            case 32: return new Color(0.50f, 0.00f, 0.50f);  // Magenta Dark
            case 33: return new Color(0.50f, 0.00f, 1.00f);  // Indigo
            case 34: return new Color(0.25f, 0.00f, 0.50f);  // Indigo Dark
        }

        return Color.gray;
    }

}

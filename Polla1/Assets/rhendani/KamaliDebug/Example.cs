using UnityEngine;
using KamaliDebug;
public class Example : MonoBehaviour
{

    float asd = 500;
    float asddd = 52300;

    private void Start()
    {
        DebugX.Log(@"I:orange:b; love:red:b; Unity:yellow:b;
        ColorfullllllllllllllllText:rainbow:b;");
    
        DebugX.Log(@"sniper:orange:b; bug:green:b;");
        DebugX.Log($"Score = {asd}:yellow:b;");
        DebugX.Log($"Health = {asddd}:green:b;");
    }
}
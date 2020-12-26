using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class r_start_chat : MonoBehaviour
{

    public ChatFirst chat;

    void Start()
    {
        chat.Run();
        write.b("this runs " + name);
    }

    void Update()
    {
        
    }
}

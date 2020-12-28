using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectButton : MonoBehaviour
{

    public bool isPressed;
    public bool locked;
    // public float speed;
    public bool canChangeMaterial;
    public Material normalMat;
    public Material pressedMat;
    //[ShowTitle("USE OUTLINE")]
    public bool canUseOutline;
    //public HighlightedObject outline;

    public UnityEngine.Events.UnityEvent onPressed;
    public UnityEngine.Events.UnityEvent onUnpressed;

    bool canActivate;
    bool once;
    void Start()
    {

        if (isPressed)
        {
            once = false;
            if (canChangeMaterial) GetComponent<Renderer>().material = pressedMat;
        }
        else
        {
            once = true;
            if (canChangeMaterial) GetComponent<Renderer>().material = normalMat;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canActivate) isPressed = !isPressed;

        if (isPressed && !locked && !once)
        {
            onPressed.Invoke();
            if (canChangeMaterial) GetComponent<Renderer>().material = pressedMat;
            once = true; print("PRESS");
        }
        else if (!isPressed && !locked && once)
        {
            onUnpressed.Invoke();
            if (canChangeMaterial) GetComponent<Renderer>().material = normalMat;
            once = false; print("UNPRESS");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("CHARACTER"))
        {
            //if (canUseOutline) outline.outlineActive = true;
            canActivate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("CHARACTER"))
        {
            //if (canUseOutline) outline.outlineActive = false;
            canActivate = false;
        }
    }
}

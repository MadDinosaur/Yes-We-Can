using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Tilia.Interactions.SpatialButtons;

public class MiniMenuController : MonoBehaviour
{
    public GameObject miniMenu;
    public GameObject pointer;

    bool pointerAlwaysOn;

    public UnityEvent OnTriggered;

    // Start is called before the first frame update
    void Start()
    {
        if (pointer.activeSelf) pointerAlwaysOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Trigger()
    {
        miniMenu.SetActive(!miniMenu.activeSelf);
        if (!pointerAlwaysOn) pointer.SetActive(!pointer.activeSelf);
        OnTriggered.Invoke();
    }

    public bool isActive()
    {
        return miniMenu.activeSelf;
    }

    public void checkOverlap()
    {
        if (isActive())
        {
            miniMenu.SetActive(!miniMenu.activeSelf);
            if (!pointerAlwaysOn) pointer.SetActive(!pointer.activeSelf);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tilia.Interactions.SpatialButtons;

public class MiniMenuController : MonoBehaviour
{
    public GameObject miniMenu;
    public GameObject pointer;

    bool pointerAlwaysOn;

    // Start is called before the first frame update
    void Start()
    {
        if (pointer.activeSelf) pointerAlwaysOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void trigger()
    {
        miniMenu.SetActive(!miniMenu.activeSelf);
        if (!pointerAlwaysOn) pointer.SetActive(!pointer.activeSelf);
    }
}

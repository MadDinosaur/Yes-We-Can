using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBlindStick : MonoBehaviour
{
    public GameObject hand;
    public GameObject blindstick;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle()
    {
        hand.SetActive(!hand.activeSelf);
        blindstick.SetActive(!blindstick.activeSelf);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfigurations : MonoBehaviour
{
    public bool physicalGameMode;

    // Start is called before the first frame update
    void Start()
    {
        if (physicalGameMode)
        {
            GameObject.Find("Teleporter").SetActive(false);
            GameObject.Find("AxisMove").SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

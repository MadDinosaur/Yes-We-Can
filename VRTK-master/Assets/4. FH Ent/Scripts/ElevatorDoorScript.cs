using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ElevatorDoorScript : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;
    public float speed = 0.005f;
    public float distance = 0.01f;
    bool open;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            if (Math.Abs(leftDoor.transform.localPosition.x - rightDoor.transform.localPosition.x) < distance)
            {
                leftDoor.transform.localPosition += Vector3.right * speed;
                rightDoor.transform.localPosition += Vector3.left * speed;
            }
        }
        else open = false;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Headset"))
        {
            open = true;
        }
    }
}

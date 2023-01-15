using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoorScript : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;
    public float speed = 0.005f;
    float leftDoorStartDist;
    float distance = 0.01f;
    bool open;
    
    // Start is called before the first frame update
    void Start()
    {
        leftDoorStartDist = leftDoor.transform.position.x;

        open = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(open)
        {
            if (leftDoor.transform.position.x - leftDoorStartDist > distance)
            {
                leftDoor.transform.position += Vector3.right * speed;
                rightDoor.transform.position += Vector3.left * speed;
            }
            else open = false;
        }
    }

}

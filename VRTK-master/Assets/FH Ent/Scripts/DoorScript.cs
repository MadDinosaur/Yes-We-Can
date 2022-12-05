using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    const int openDoorRightPosition = 90;

    Transform doorLeft;
    Transform doorRight;

    void Start()
    {
     
        List<Transform> children = GetChildren(transform, true);

        foreach(Transform child in children) {
            Debug.Log(child.name);
            if (child.name == "Door.002") {
                doorLeft = child;
                Vector3 newRotation = new Vector3(89.98f, 0, 0);
                doorLeft.transform.eulerAngles = newRotation;
            }
            if (child.name == "Door.003") {
                doorRight = child;
                Vector3 newRotation = new Vector3(89.98f, 0, 0);
                doorRight.transform.eulerAngles = newRotation;
            }
        }
        
        
    }

    List<Transform> GetChildren(Transform parent, bool recursive) {
        List<Transform> children = new List<Transform>();

        foreach(Transform child in parent) {
            children.Add(child);
            if(recursive) {
                children.AddRange(GetChildren(child, true));
            }
        }

        return children;
    }

    // Update is called once per frame
    void Update()
    {
        openDoorRight();
    }

    void openDoorRight() {
        Vector3 newRotation = doorRight.transform.eulerAngles;
        if (newRotation.y < openDoorRightPosition) {
            newRotation.y += 0.1f;
            doorRight.transform.eulerAngles = newRotation;

            newRotation.y = -newRotation.y;
            doorLeft.transform.eulerAngles = newRotation;
        } 
    }
}

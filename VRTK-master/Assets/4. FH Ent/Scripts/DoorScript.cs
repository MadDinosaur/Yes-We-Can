using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorScript : MonoBehaviour
{
    public float speed = 50f;
    public float duration = 5;
    public bool openOnStart;

    bool opening;

    const int openDoorRightPosition = 90;

    Transform doorLeft;
    Transform doorRight;

    public UnityEvent onOpened;

    void Start()
    {

        List<Transform> children = GetChildren(transform, true);

        foreach (Transform child in children)
        {
            if (child.name == "Door.002")
            {
                doorLeft = child;
                Vector3 newRotation = new Vector3(89.98f, 0, 0);
                doorLeft.transform.eulerAngles = newRotation;
            }
            if (child.name == "Door.003")
            {
                doorRight = child;
                Vector3 newRotation = new Vector3(89.98f, 0, 0);
                doorRight.transform.eulerAngles = newRotation;
            }
        }

        if (openOnStart) opening = true;
    }

    List<Transform> GetChildren(Transform parent, bool recursive)
    {
        List<Transform> children = new List<Transform>();

        foreach (Transform child in parent)
        {
            children.Add(child);
            if (recursive)
            {
                children.AddRange(GetChildren(child, true));
            }
        }

        return children;
    }

    // Update is called once per frame
    void Update()
    {
        if (opening) { 
                onOpened.Invoke();
                openDoor();
        }
    }

    public void openDoors()
    {
        opening = true;
    }

    void openDoor()
    {
        Vector3 newRotation = doorRight.transform.eulerAngles;
        if (newRotation.y <= openDoorRightPosition || newRotation.y > 360 - speed)
        {
            newRotation.y += speed * Time.deltaTime;
            doorRight.transform.eulerAngles = newRotation;

            newRotation.y = -newRotation.y;
            doorLeft.transform.eulerAngles = newRotation;
        }
        else
        {
            opening = false;
            foreach (BoxCollider collider in GetComponentsInChildren<BoxCollider>())
            {
                collider.enabled = false;
            }
        }
    }

       /* void closeDoor()
        {
            doorStatus = status.Closing;

            Vector3 newRotation = doorRight.transform.eulerAngles;
            if (newRotation.y >= 0 && newRotation.y <= openDoorRightPosition + speed)
            {
                newRotation.y -= speed * Time.deltaTime;
                doorRight.transform.eulerAngles = newRotation;

                newRotation.y = -newRotation.y;
                doorLeft.transform.eulerAngles = newRotation;
            }
            else doorStatus = status.Closed;
        }

        IEnumerator WaitToClose()
        {
            doorStatus = status.Waiting;

            yield return new WaitForSeconds(duration);

            closeDoor();
        }*/
    }

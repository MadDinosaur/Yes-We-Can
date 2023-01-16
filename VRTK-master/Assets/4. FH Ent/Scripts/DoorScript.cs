using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public float speed = 0.5f;
    public float duration = 5;
    public bool openOnStart;

    enum status
    {
        Opening,
        Open,
        Waiting,
        Closing,
        Closed
    }
    status doorStatus = status.Closed;

    const int openDoorRightPosition = 90;

    Transform doorLeft;
    Transform doorRight;

    void Start()
    {

        List<Transform> children = GetChildren(transform, true);

        foreach (Transform child in children)
        {
            Debug.Log(child.name);
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

        if (openOnStart) doorStatus = status.Opening;
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
        Debug.Log(doorStatus);
        switch (doorStatus)
        {
            case status.Opening:
                openDoor();
                break;
                /*case status.Open:
                    StartCoroutine(WaitToClose());
                    break;
                case status.Closing:
                    closeDoor();
                    break;*/
        }
    }

    public void openDoors()
    {
        Debug.Log("here");
        doorStatus = status.Opening;
    }

    void openDoor()
    {
        Vector3 newRotation = doorRight.transform.eulerAngles;
        Debug.Log(newRotation);
        if (newRotation.y <= openDoorRightPosition || newRotation.y > 360 - speed)
        {
            newRotation.y += speed;
            doorRight.transform.eulerAngles = newRotation;

            newRotation.y = -newRotation.y;
            doorLeft.transform.eulerAngles = newRotation;
        }
        else
        {
            doorStatus = status.Open;
            foreach (BoxCollider collider in GetComponentsInChildren<BoxCollider>())
            {
                collider.enabled = false;
            }
        }
    }

        void closeDoor()
        {
            doorStatus = status.Closing;

            Vector3 newRotation = doorRight.transform.eulerAngles;
            if (newRotation.y >= 0 && newRotation.y <= openDoorRightPosition + speed)
            {
                newRotation.y -= speed;
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
        }
    }

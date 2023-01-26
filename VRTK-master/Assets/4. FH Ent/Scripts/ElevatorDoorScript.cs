using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ElevatorDoorScript : MonoBehaviour
{
    public GameObject reflectionCamera;
    public GameObject leftDoor;
    public GameObject rightDoor;
    public float speed = 0.005f;
    public float openDistance = 0.01f;
    public float closeDistance = 0.01f;
    public float waitTime;
    bool openTrigger;
    bool closeTrigger;
    
    // Start is called before the first frame update
    void Start()
    {
        //debug
        openTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (openTrigger)
        {
            if (Math.Abs(leftDoor.transform.localPosition.x - rightDoor.transform.localPosition.x) < openDistance)
            {
                leftDoor.transform.localPosition += Vector3.right * speed;
                rightDoor.transform.localPosition += Vector3.left * speed;
            } else
            {
                openTrigger = false;
                StartCoroutine(WaitForDoorClose());
            }
        } else if (closeTrigger)
        {
            if (Math.Abs(leftDoor.transform.localPosition.x - rightDoor.transform.localPosition.x) > closeDistance)
            {
                leftDoor.transform.localPosition -= Vector3.right * speed;
                rightDoor.transform.localPosition -= Vector3.left * speed;
            }
            else closeTrigger = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Headset") && !openTrigger)
        {
            openTrigger = true;
            GetComponent<AudioSource>().Play();
            reflectionCamera.SetActive(true);
        }
    }

    IEnumerator WaitForDoorClose()
    {
        yield return new WaitForSeconds(waitTime);

        closeTrigger = true;
        reflectionCamera.SetActive(false);
    }
}

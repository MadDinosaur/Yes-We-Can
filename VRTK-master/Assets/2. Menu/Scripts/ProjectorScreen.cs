using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zinnia.Pointer;

public class ProjectorScreen : MonoBehaviour
{
    bool isGrabbingRemote;
    bool isRemoteActive;

    public float speed = 0.1f;
    public GameObject menu;
    
    float targetPosY;
    float targetScaleY;

    public UnityEvent menuTriggered;

    // Start is called before the first frame update
    void Start()
    {
        //disable menu
        menu.SetActive(false);
        //get target dimensions
        targetPosY = transform.position.y;
        targetScaleY = transform.localScale.y;
        //resize screen to be hidden
        transform.position = new Vector3(transform.position.x, 2.705949f, transform.position.z);
        transform.localScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isRemoteActive)
            if (transform.localScale.y < targetScaleY)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + speed, transform.localScale.z);
                transform.position = new Vector3(transform.position.x, transform.position.y - speed/2, transform.position.z);
            } else
            {
                menuTriggered.Invoke();
                isRemoteActive = false;
                menu.SetActive(true);
                gameObject.SetActive(false);
            }
    }

        public void grabRemote()
        {
            isGrabbingRemote = true;
        }

        public void ungrabRemote()
        {
            isGrabbingRemote = false;
        }

        public void pressRemoteButton()
        {
            if (isGrabbingRemote) isRemoteActive = true;
        }
    public bool isMenuReady()
    {
        return menu.activeInHierarchy;
    }
    }
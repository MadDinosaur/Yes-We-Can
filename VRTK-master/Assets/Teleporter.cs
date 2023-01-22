using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform targetCoords;
    public GameObject target;
    public GameObject offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Teleport()
    {
        Vector3 targetPosition = new Vector3(targetCoords.transform.position.x, target.transform.position.y, targetCoords.transform.position.z);
        Vector3 offsetPosition = new Vector3(target.transform.position.x - offset.transform.position.x, 0, target.transform.position.z - offset.transform.position.z);
        target.transform.position = targetPosition + offsetPosition;
        //offset.transform.position = targetPosition;
        //Quaternion targetRotation = Quaternion.Euler(offset.transform.rotation.x, target.transform.rotation.y, offset.transform.rotation.z);
        //target.transform.rotation = targetRotation;
        GetComponent<AudioSource>().Play();
    }

    public void TeleportToOrigin()
    {
        Vector3 targetPosition = new Vector3(0, target.transform.position.y, 0);
        Vector3 offsetPosition = new Vector3(target.transform.position.x - offset.transform.position.x, 0, target.transform.position.z - offset.transform.position.z);
        target.transform.localPosition = targetPosition + offsetPosition;
        //offset.transform.position = targetPosition;
        //Quaternion targetRotation = Quaternion.Euler(offset.transform.rotation.x, target.transform.rotation.y, offset.transform.rotation.z);
        //target.transform.rotation = targetRotation;
    }
}

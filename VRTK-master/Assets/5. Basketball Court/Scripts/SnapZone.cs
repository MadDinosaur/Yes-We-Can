using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapZone : MonoBehaviour
{
    GameObject grabbedObject;
    public GameObject highlight;

    bool updateObjectPosition;
    public float threshold;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        highlight.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        highlight.SetActive(false);
    }

    public void EmitUngrabbedObject(GameObject gameObject)
    {
        if (Vector3.Distance(gameObject.transform.position, transform.position) < threshold)
        {
            grabbedObject = gameObject;
            gameObject.transform.parent = transform;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            gameObject.transform.localPosition = Vector3.zero;
        }
    }

    public void EmitGrabbedObject(GameObject gameObject) {
        if (gameObject.Equals(grabbedObject))
        {
            gameObject.transform.parent = null;
            gameObject.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezeAll;
        }
    }
}

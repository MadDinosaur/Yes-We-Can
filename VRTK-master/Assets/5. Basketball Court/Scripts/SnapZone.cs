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
        if(Input.GetKeyDown(KeyCode.Return))
        {
            grabbedObject.transform.localPosition = Vector3.zero;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        highlight.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        highlight.SetActive(false);
    }

    public void EmitUngrabbedObject(GameObject goal)
    {
        if (Vector3.Distance(goal.transform.position, transform.position) < threshold)
        {
            Debug.Log(goal.name);
            grabbedObject = goal;
            goal.transform.parent = transform;
            //goal.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            goal.GetComponent<Rigidbody>().isKinematic = true;
            goal.GetComponent<Rigidbody>().useGravity = false;

            StartCoroutine(FixPosition());
        }
    }

    public IEnumerator FixPosition()
    {
        yield return new WaitForSeconds(0.5f);

        grabbedObject.transform.localPosition = Vector3.zero;
    }

    public void EmitGrabbedObject(GameObject goal) {
        if (goal.Equals(grabbedObject))
        {
            goal.transform.parent = null;
            goal.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezeAll;
        }
    }
}

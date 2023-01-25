using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapZone : MonoBehaviour
{
    GameObject grabbedObject;
    public GameObject highlight;

    bool updateObjectPosition;
    public float threshold;

    float tempTime;
    bool triggerFixPos = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (triggerFixPos && Time.deltaTime - tempTime > 0.5f) FixPosition();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Basketball"))
            highlight.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Basketball"))
            highlight.SetActive(false);
    }

    public void EmitUngrabbedObject(GameObject goal)
    {
        if (Vector3.Distance(goal.transform.position, transform.position) < threshold)
        {
            Debug.Log(goal.name);
            grabbedObject = goal;
            goal.transform.parent = transform;
            goal.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            /*goal.GetComponent<Rigidbody>().isKinematic = true;
            goal.GetComponent<Rigidbody>().useGravity = false;*/


            tempTime = Time.deltaTime;
            triggerFixPos = true;
            //StartCoroutine(FixPosition());

        }
    }

    /*public IEnumerator FixPosition()
    {
        yield return new WaitForSeconds(0.5f);

        grabbedObject.transform.localPosition = Vector3.zero;
    }*/

    public void FixPosition()
    {
        grabbedObject.transform.localPosition = Vector3.zero;
        triggerFixPos = false;
    }

    public void EmitGrabbedObject(GameObject goal) {
        if (grabbedObject.Equals(goal))
        {
            grabbedObject.transform.parent = null;
            goal.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezeAll; 
            /*grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject.GetComponent<Rigidbody>().useGravity = true;*/
        }
    }
}

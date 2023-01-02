using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag.Equals("Marker")) Debug.Log("Marker detected");
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Marker"))
        {
            Vector3 markerPos = collision.gameObject.transform.position;
            Debug.Log("Collision at: (" + markerPos.x + ", " + markerPos.y + ", " + markerPos.z + ")");
        }
    }
}

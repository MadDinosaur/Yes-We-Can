using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnUngrabbed : MonoBehaviour
{
    public float threshold;
    Vector3 startPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector3.Distance(transform.position, startPosition));
        if (Vector3.Distance(transform.position, startPosition) > threshold)
        {
            transform.position = startPosition;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}

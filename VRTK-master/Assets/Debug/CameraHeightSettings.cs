using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHeightSettings : MonoBehaviour
{
    public float buildHeight;
    public float editorHeight;
    public bool build;

    // Start is called before the first frame update
    void Start()
    {
        if (build)
            transform.position = new Vector3(transform.position.x, buildHeight, transform.position.z);
        else 
            transform.position = new Vector3(transform.position.x, editorHeight, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

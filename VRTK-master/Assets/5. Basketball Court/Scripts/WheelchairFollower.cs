using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelchairFollower : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, target.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z); 
    }
}

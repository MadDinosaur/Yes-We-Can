using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleHandColliders : MonoBehaviour
{
    public Collider rightHandCollider;
    public Collider leftHandCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        rightHandCollider.enabled = true;
        leftHandCollider.enabled = true;
    }
}

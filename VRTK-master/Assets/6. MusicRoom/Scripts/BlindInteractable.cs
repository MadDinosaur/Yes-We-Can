using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindInteractable : MonoBehaviour
{
    public Material standardMat;
    public Material glowMat;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivateGlow()
    {
        GetComponent<MeshRenderer>().material = standardMat;
    }

    public void ActivateGlow()
    {
        GetComponent<MeshRenderer>().material = glowMat;
    }
}

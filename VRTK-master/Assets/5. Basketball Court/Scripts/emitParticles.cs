using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class emitParticles : MonoBehaviour
{
    public ParticleSystem clouds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HIT");
        
        ParticleSystem cloudsInstance = Instantiate(clouds, transform.position, Quaternion.identity);
    }
}

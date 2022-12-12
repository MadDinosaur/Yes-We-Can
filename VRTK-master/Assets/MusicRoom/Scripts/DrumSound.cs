using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag.Equals("DrumStick"))
        {
            AudioSource note = GetComponent<AudioSource>();
            note.Play();
        }
    }
}

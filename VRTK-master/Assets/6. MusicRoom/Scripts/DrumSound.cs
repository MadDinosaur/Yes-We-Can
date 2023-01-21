using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumSound : MonoBehaviour
{
    public Highlighter highlighter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);

        AudioSource note = GetComponent<AudioSource>();
        if (note.isPlaying) { note.Stop(); note.Play(); }
        else note.Play();

    }*/

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        AudioSource note = GetComponent<AudioSource>();
        if (note.isPlaying) { note.Stop(); note.Play(); }
        else note.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        highlighter.Unhighlight();
    }
}
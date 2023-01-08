using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highlighter : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Material highlightMaterial;
    public string key;

    PianoSongController controller;
    Material standardMaterial;
    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponentInParent<PianoSongController>();
        standardMaterial = meshRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
         if (controller.CheckIfHighlighted(key)) meshRenderer.material = highlightMaterial;
    }

    public void Unhighlight()
    {
        if (controller.CheckIfHighlighted(key))
        {
            controller.EmitNote(key);
            meshRenderer.material = standardMaterial;
        }
    }
}

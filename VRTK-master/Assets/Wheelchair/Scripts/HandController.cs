using System;
using UnityEngine;
using UnityEngine.Events;

public class HandController : MonoBehaviour
{
    Animator animator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateGrip()
    {
        animator.SetBool("isGripping", true);
    }

    public void DeactivateGrip()
    {
        animator.SetBool("isGripping", false);
    }
}

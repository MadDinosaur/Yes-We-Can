using System;
using UnityEngine;
using UnityEngine.Events;

public class HandController : MonoBehaviour
{
    public Animator animator;
    
    
    // Start is called before the first frame update
    void Start()
    {
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

    public void ActivatePoint()
    {
        animator.SetBool("isPointing", true);
    }

    public void DeactivatePoint()
    {
        animator.SetBool("isPointing", false);
    }
}

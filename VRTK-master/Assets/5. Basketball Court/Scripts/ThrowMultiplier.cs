using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowMultiplier : MonoBehaviour
{
    public float multiplier = 1000;
    Vector3 startPos;
    //bool isFirstFrame;
    //public bool isThrowing = false;

    public void AddThrowingMultiplier()
    {
        GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity*multiplier);
    }

    /*public void IsThrowing(bool value)
    {
        isThrowing = value;
    }

    public void Update()
    {
        if (isThrowing)
        {
            if (isFirstFrame)
            {
                startPos = transform.position;
            }
            else
            {
                Vector3 offset = startPos - transform.position;
                GetComponent<Rigidbody>().AddForce(offset * multiplier);
                isThrowing = false;
            }
        }

    }*/
}

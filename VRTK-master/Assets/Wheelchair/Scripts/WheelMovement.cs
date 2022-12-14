using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tilia.Interactions.Controllables.AngularDriver;


public class WheelMovement : MonoBehaviour
{
    public float turnRadius = 5, maxRotation = 90, rotationSpeed = 1;
    public GameObject leftWheel, rightWheel;
    float leftCurrSpeed = 0, rightCurrSpeed = 0;
    bool leftWheelActive, rightWheelActive;

    // Start is called before the first frame update
    void Start()
    {
        rightWheel.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        leftWheel.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (leftWheelActive) GetVelocityLeft();
        if (rightWheelActive) GetVelocityRight();
    }

    void Teleport()
    {
        //Playarea
        transform.parent.parent.SetPositionAndRotation(new Vector3(transform.position.x, transform.parent.parent.position.y,transform.position.z),transform.rotation);
        //Ghost
        transform.localPosition = new Vector3(0, 0, 0);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    /* Right Wheel */
    public void ActivateWheelRight()
    {
        Debug.Log("Right wheel activated.");
        rightWheelActive = true;
        //--Activate X rotation on wheel--//
        rightWheel.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeRotationX;
    }

    public void DeactivateWheelRight()
    {
        Debug.Log("Right wheel deactivated.");
        rightWheelActive = false;
        
        //--Deactivate X rotation on wheel--//
        rightWheel.GetComponent<Transform>().localRotation = Quaternion.Euler(0, 0, 90);

        Teleport();
        
        rightWheel.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public void GetVelocityRight()
    {
        float controllerInput = rightWheel.transform.rotation.eulerAngles.x;
        //No movement detected
        if (controllerInput == 0)
            return;
        
        if (!leftWheelActive && rightWheelActive)
            MoveVirtualPositionRight(controllerInput); //Only right wheel detected
        else if (leftWheelActive && rightWheelActive)
            MoveVirtualPositionForward(controllerInput); //Both wheels detected
    }

    /* Left Wheel */
    public void ActivateWheelLeft()
    {
        Debug.Log("Left wheel activated.");
        leftWheelActive = true;
        //--Activate X rotation on wheel--//
        leftWheel.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeRotationY;
    }

    public void DeactivateWheelLeft()
    {
        Debug.Log("Left wheel deactivated.");
        leftWheelActive = false;
        
        //--Deactivate X rotation on wheel--//
        leftWheel.GetComponent<Transform>().localRotation = Quaternion.Euler(0, 0, 90);

        Teleport();

        leftWheel.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public void GetVelocityLeft()
    {
        float controllerInput = leftWheel.transform.rotation.eulerAngles.x;
        //No movement detected
        if (controllerInput == 0)
            return;

        if (!rightWheelActive && leftWheelActive)
            MoveVirtualPositionLeft(controllerInput); //Only left wheel detected
    }

    void MoveVirtualPositionRight(float controllerInput)
    {
        //Multiplication factor standardizes the input to a value accepted by the semicircle equation
        float multiplicationFactor = maxRotation / (turnRadius * 2);
        float x = -controllerInput / multiplicationFactor;
        Debug.Log("Input : " + controllerInput + "; X : " + x);
        float y = transform.position.y + 0;
        //Apply a semicircle equation, one for forward motion other for backward motion
        float z;
        if (controllerInput < maxRotation)
        {
            z = (float)Math.Sqrt(Math.Pow(turnRadius, 2) - Math.Pow((-x + transform.parent.position.x - turnRadius), 2)) + transform.parent.position.z; //formula of a semicircle
        } else
        {
            x = (controllerInput - 360) / multiplicationFactor;
            z = -((float)Math.Sqrt(Math.Pow(turnRadius, 2) - Math.Pow((-x + transform.parent.position.x - turnRadius), 2)) + transform.parent.position.z); //formula of a semicircle
        }
        //Moving the virtual position
        Vector3 prevPosition = transform.position;
        transform.localPosition = new Vector3(x, y, z-transform.parent.position.z);
        Vector3 currPosition = transform.position;
        //Rotating virtual position
        Vector3 movementDirection = currPosition - prevPosition;
        Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        //Updating previous frame information
        rightCurrSpeed = controllerInput;
    }

    void MoveVirtualPositionLeft(float controllerInput)
    {
        //Multiplication factor standardizes the input to a value accepted by the semicircle equation
        float multiplicationFactor = maxRotation / (turnRadius * 2);
        float x = controllerInput / multiplicationFactor;
        Debug.Log("Input : " + controllerInput + "; X : " + x);
        float y = transform.position.y + 0;
        //Apply a semicircle equation, one for forward motion other for backward motion
        float z;
        if (controllerInput < maxRotation)
        {
            z = (float)Math.Sqrt(Math.Pow(turnRadius, 2) - Math.Pow((x - turnRadius), 2)) + transform.parent.position.z; //formula of a semicircle
        } else
        {
            x = -(controllerInput - 360) / multiplicationFactor;
            z = -((float)Math.Sqrt(Math.Pow(turnRadius, 2) - Math.Pow((x - turnRadius), 2)) + transform.parent.position.z); //formula of a semicircle
        }
        //Moving the virtual position
        Vector3 prevPosition = transform.position;
        transform.position = new Vector3(x, y, z);
        Vector3 currPosition = transform.position;
        //Rotating virtual position
        Vector3 movementDirection = currPosition - prevPosition;
        Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        //Update previous frame information
        leftCurrSpeed = controllerInput;
    }

    void MoveVirtualPositionForward(float controllerInput)
    {
        ///Calculate speed by subtracting wheel position on previous frame to current frame
        float multiplicationFactor = maxRotation / (turnRadius * 2);
        float x = transform.position.x + 0;
        float y = transform.position.y + 0;
        float z;
        if (controllerInput < maxRotation)
        z = controllerInput / multiplicationFactor; 
        else
        z = (controllerInput-360) / multiplicationFactor;
        Debug.Log("Input : " + controllerInput + "; Z : " + z);
        //Moving the virtual position
        transform.position = new Vector3(x, y, z);
    }

    void DebugWheelRight()
    {
        ActivateWheelRight();
        StartCoroutine(DebugTeleport());
    }

    IEnumerator DebugTeleport()
    {
        yield return new WaitForSecondsRealtime(10);

        DeactivateWheelRight();
    }
}
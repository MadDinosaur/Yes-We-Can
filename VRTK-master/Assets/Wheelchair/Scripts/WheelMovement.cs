using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tilia.Interactions.Controllables.AngularDriver;


public class WheelMovement : MonoBehaviour
{
    public float turnRadius, drag, rotationSpeed;
    public GameObject rightWheelJoint, rightWheelJointContainer, leftWheelJoint, leftWheelJointContainer;
    float leftCurrSpeed = 0, rightCurrSpeed = 0;
    bool leftWheelActive, rightWheelActive;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

    }

    void Teleport()
    {
        //Playarea
        transform.parent.parent.SetPositionAndRotation(new Vector3(transform.position.x, transform.parent.parent.position.y,transform.position.z),transform.rotation);
        //Ghost
        transform.SetPositionAndRotation(transform.parent.position, transform.parent.rotation);
    }

    /* Right Wheel */
    public void ActivateWheelRight()
    {
        rightWheelActive = true;
        //--Activate X rotation on wheel--//
        rightWheelJoint.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeRotationX;
        rightWheelJointContainer.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeRotationX;
    }

    public void DeactivateWheelRight()
    {
        rightWheelActive = false;
        
        //--Deactivate X rotation on wheel--//
        rightWheelJoint.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
        rightWheelJointContainer.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);

        Teleport();
        
        rightWheelJoint.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        rightWheelJointContainer.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public void GetVelocityRight(float controllerInput)
    {
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
        leftWheelActive = true;
        //--Activate X rotation on wheel--//
        leftWheelJoint.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeRotationX;
        leftWheelJointContainer.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeRotationX;
    }

    public void DeactivateWheelLeft()
    {
        leftWheelActive = false;
        Teleport();
        //--Deactivate X rotation on wheel--//
        rightWheelJoint.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
        rightWheelJointContainer.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);

        rightWheelJoint.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        rightWheelJointContainer.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public void GetVelocityLeft(float controllerInput)
    {

        //No movement detected
        if (controllerInput == 0)
            return;

        if (!rightWheelActive && leftWheelActive)
            MoveVirtualPositionLeft(controllerInput); //Only left wheel detected
    }

    void MoveVirtualPositionRight(float controllerInput)
    {
        //Calculate speed by subtracting wheel position on previous frame to current frame
        float speed = (controllerInput - rightCurrSpeed)/drag;
        Debug.Log("Input: " + controllerInput + "; Right wheel speed: " + speed + "; Current coordinate: " + transform.position.x + "; Next coordinate: " + (transform.position.x - speed));
        //Moving the virtual position
        float x = controllerInput;
        float y = transform.position.y + 0;
        float z = (float) Math.Sqrt(Math.Pow(turnRadius, 2) - Math.Pow((-x - turnRadius), 2)); //formula of a semicircle
        Vector3 prevPosition = transform.position;
        transform.position = new Vector3(x, y, z);
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
        //Calculate speed by subtracting wheel position on previous frame to current frame
        float speed = (controllerInput - leftCurrSpeed)/drag;
        Debug.Log("Left wheel speed: " + speed + "; Current coordinate: " + transform.position.x + "; Next coordinate: " + (transform.position.x + speed));
        //Moving the virtual position
        float x = transform.position.x + speed;
        float y = transform.position.y + 0;
        float z = (float) Math.Sqrt(Math.Pow(turnRadius, 2) - Math.Pow((x - turnRadius), 2)); //formula of a semicircle
        Vector3 prevPosition = transform.position;
        transform.position = new Vector3(x, y, z);
        Vector3 currPosition = transform.position;
        Debug.Log("Ghost current position: " + transform.position);
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
        float speed = (controllerInput - rightCurrSpeed)/drag;
        //Updating previous frame information
        rightCurrSpeed = controllerInput;
        //Moving the virtual position
        transform.position += Vector3.forward * speed;
    }

    void OnTargetValueReached()
    {
        Debug.Log("Wheel stopped");
    }
}
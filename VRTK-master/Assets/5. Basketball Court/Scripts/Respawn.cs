using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    Vector3 startPos;
    public float respawnTimer = 3;
    float respawnStartTime;
    
    bool isAbleToRespawn = false;
    bool startRespawnTime = false;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }



    void RespawnObject()
    {
        transform.position = startPos;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        isAbleToRespawn = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (startRespawnTime)
        {
            if(Time.time - respawnStartTime > respawnTimer)
            {
                RespawnObject();
                startRespawnTime = false;
            }   
        }

        if(GetComponent<Rigidbody>().velocity == Vector3.zero && isAbleToRespawn)
        {
            Debug.Log("StartRespawn");
            respawnStartTime = Time.time;
            startRespawnTime = true;
            isAbleToRespawn = false;
        }

    }


    public void ReadyToRespawn()
    {
        isAbleToRespawn = true;
    }

    




}

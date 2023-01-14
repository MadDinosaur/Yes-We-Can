using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionScreenController : MonoBehaviour
{
    public GameObject instructionScreen;
    bool gameStartTrigger = true;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instructionScreen.activeSelf) gameStartTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Trigger()
    {
        instructionScreen.SetActive(!instructionScreen.activeSelf);
        if (!gameStartTrigger) gameStartTrigger = true;
    }

    public bool IsGameStarted()
    {
        return gameStartTrigger;
    }
}

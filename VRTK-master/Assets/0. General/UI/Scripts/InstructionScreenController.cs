using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InstructionScreenController : MonoBehaviour
{
    public GameObject instructionScreen;
    public GameObject miniMenu;
    bool gameStartTrigger = true;

    public UnityEvent OnTriggered;
    
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
        OnTriggered.Invoke();
    }

    public bool IsGameStarted()
    {
        return gameStartTrigger;
    }

    public bool isActive()
    {
        return instructionScreen.activeSelf;
    }

    public void checkOverlap()
    {
        if (isActive())
        {
            instructionScreen.SetActive(!instructionScreen.activeSelf);
            if (!gameStartTrigger) gameStartTrigger = true;
        }
    }
}

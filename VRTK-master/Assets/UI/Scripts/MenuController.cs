using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject exitPrompt;

    public GameObject miniMenu;
    public GameObject pointer;
    
    public GameObject instructionScreen;
    public List<Sprite> images;


    bool pointerAlwaysOn;
    bool gameStartTrigger = true;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (pointer.activeSelf) pointerAlwaysOn = true;
        if (instructionScreen.activeSelf) gameStartTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerMiniMenu()
    {
        if (!gameObject.activeSelf) return; 

        if (!instructionScreen.activeSelf && !exitPrompt.activeSelf)
        {
            miniMenu.SetActive(!miniMenu.activeSelf);
            if (!pointerAlwaysOn) pointer.SetActive(!pointer.activeSelf);
        }
    }

    public void TriggerInstructionScreen()
    {
        if (!gameObject.activeSelf) return;

        if (!miniMenu.activeSelf && !exitPrompt.activeSelf)
        {
            instructionScreen.SetActive(!instructionScreen.activeSelf);
            instructionScreen.GetComponentInChildren<Image>().sprite = images[0];
            index = 0;
            if (!gameStartTrigger) gameStartTrigger = true;
        }
    }

    public bool IsGameStarted()
    {
        return gameStartTrigger;
    }

    public void NavigateInstructions()
    {
        if (!gameObject.activeSelf) return;

        if (!instructionScreen.activeSelf) return;
        
        index += 1;
        if (index == images.Count) { TriggerInstructionScreen(); index = 0; }
        
        instructionScreen.GetComponentInChildren<Image>().sprite = images[index];
        instructionScreen.GetComponent<AudioSource>().Play();
    }

    private void OnEnable()
    {
        instructionScreen.GetComponentInChildren<Image>().sprite = images[0];
    }
}

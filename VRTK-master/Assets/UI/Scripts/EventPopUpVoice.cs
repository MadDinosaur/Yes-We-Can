using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventPopUpVoice : MonoBehaviour 
{ 
    public GameObject uiObject;
    public UnityEvent onFinished;

    public float delay = 0;

    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
    }

    IEnumerator WaitForVoiceLine(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);

        onFinished.Invoke();
        Destroy(uiObject);
        Destroy(this.gameObject);
    }

    IEnumerator WaitForDelay(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);

        //Activate UI overlay
        uiObject.SetActive(true);
        //Determine duration of voice line and play
        AudioSource voiceLine = GetComponentInChildren<AudioSource>();
        double clipLength = voiceLine.clip.length;
        //Keep UI active until voice line is done
        StartCoroutine(WaitForVoiceLine((float)clipLength));
    }

    public void TriggerVoiceLine()
    {
        if (!gameObject.activeSelf) return;

        //Wait for delay timer
        StartCoroutine(WaitForDelay(delay));
    }
}



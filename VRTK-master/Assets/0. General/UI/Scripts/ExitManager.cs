using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExitManager : MonoBehaviour
{
    public GameObject exitPrompt;
    public GameObject pointer;
    public GameObject voiceLine;

    public UnityEvent OnTriggered;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Trigger()
    {
            voiceLine.GetComponent<EventPopUpVideo>().TriggerVoiceLine();
            float duration = voiceLine.GetComponentInChildren<AudioSource>().clip.length;
            StartCoroutine(WaitForVoiceLine(duration));
    }

    IEnumerator WaitForVoiceLine(float duration)
    {
        yield return new WaitForSeconds(duration);

        OnTriggered.Invoke();
    }

    void ShowUI()
    {
        exitPrompt.SetActive(true);
        pointer.SetActive(true);
    }
}

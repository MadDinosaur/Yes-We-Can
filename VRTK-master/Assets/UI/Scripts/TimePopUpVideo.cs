using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePopUpVideo : MonoBehaviour
{
    public GameObject uiObject;
    public MenuController controller;
    public float duration;
    enum status
    {
        Standby,
        Started,
        Playing
    }
    status readyToTrigger = status.Standby;

    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
    }

    void Update()
    {
        switch (readyToTrigger)
        {
            case status.Standby:
                readyToTrigger = controller.IsGameStarted() ?  status.Started : status.Standby;
                break;
            case status.Started:
                StartCoroutine(WaitForTimeTrigger(duration));
                readyToTrigger = status.Playing;
                break;
            default:
                break;
        }
    }

    IEnumerator WaitForVoiceLine(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);

        Destroy(uiObject);
        Destroy(this.gameObject);
    }

    IEnumerator WaitForTimeTrigger(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);

        //Activate UI overlay
        uiObject.SetActive(true);
        //Determine duration of voice line and play
        UnityEngine.Video.VideoPlayer voiceLine = GetComponentInChildren<UnityEngine.Video.VideoPlayer>();
        double clipLength = voiceLine.clip.length;
        //Keep UI active until voice line is done
        StartCoroutine(WaitForVoiceLine((float)clipLength));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPopUpVideo : MonoBehaviour
{
    public GameObject uiObject;

    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
    }

    IEnumerator WaitForVoiceLine(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);

        Destroy(uiObject);
        Destroy(this.gameObject);
    }

    public void TriggerVoiceLine()
    {
        //Activate UI overlay
        uiObject.SetActive(true);
        //Determine duration of voice line and play
        UnityEngine.Video.VideoPlayer voiceLine = GetComponentInChildren<UnityEngine.Video.VideoPlayer>();
        double clipLength = voiceLine.clip.length;
        //Keep UI active until voice line is done
        StartCoroutine(WaitForVoiceLine((float)clipLength));
    }
}


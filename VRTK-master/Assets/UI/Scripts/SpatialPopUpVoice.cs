using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatialPopUpVoice : MonoBehaviour
{

    public GameObject uiObject;

    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Headset")
        {
            //Deactivate collider
            GetComponent<Collider>().enabled = false;
            //Activate UI overlay
            uiObject.SetActive(true);
            //Determine duration of voice line and play
            AudioSource voiceLine = GetComponentInChildren<AudioSource>();
            float duration = voiceLine.clip.length;
            voiceLine.Play();
            //Keep UI active until voice line is done
            StartCoroutine(WaitForSec(duration));
        }
    }
    IEnumerator WaitForSec(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);

        Destroy(uiObject);
        Destroy(this.gameObject);
    }

}

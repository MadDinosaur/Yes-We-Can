using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatialPopUpVideo : MonoBehaviour
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
            UnityEngine.Video.VideoPlayer voiceLine = transform.parent.gameObject.GetComponentInChildren<UnityEngine.Video.VideoPlayer>();
            double duration = voiceLine.clip.length;
            //Keep UI active until voice line is done
            StartCoroutine(WaitForSec((float)duration));
        }
    }
    IEnumerator WaitForSec(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);

        Destroy(uiObject);
        Destroy(this.gameObject);
    }

}

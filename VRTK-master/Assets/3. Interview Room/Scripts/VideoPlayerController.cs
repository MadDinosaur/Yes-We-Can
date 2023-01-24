using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer vP;
    public UnityEvent onVideoEndEvent;




    // Start is called before the first frame update
    void Start()
    {
        //vP = GetComponent<VideoPlayer>();
        vP.loopPointReached += onVideoEnd;
    }

    void onVideoEnd(VideoPlayer vp)
    {
        onVideoEndEvent.Invoke();
    }

    
}

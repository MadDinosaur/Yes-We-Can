using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    int totalPieces = 16;
    int snappedPieces = 1;

    public EventPopUpVideo voiceLine;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSnappedPiece()
    {
        snappedPieces += 1;
        Debug.Log(snappedPieces);
        if (snappedPieces == totalPieces) voiceLine.TriggerVoiceLine();
    }
}

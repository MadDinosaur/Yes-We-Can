using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SongController : MonoBehaviour
{
    public List<string> notesequence = new List<string>{ "C5", "B4", "A4", "G4", "F4", "G4", "A4", "C5", "B4", "A4", "C5", "F4", "E4" };
    List<string> currentsequence = new List<string>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EmitNote(string note)
    {
        if (currentsequence.Count < notesequence.Count)
        {
            //Add note to current sequence
            currentsequence.Add(note);

            //Cut original note sequence to appropriate size
            List<string> truncatednotesequence = notesequence.GetRange(0, currentsequence.Count);
            Debug.Log("current: " + currentsequence);
            Debug.Log("correct: " + truncatednotesequence);
            //Compare sequences
            bool correctnote = currentsequence.SequenceEqual(truncatednotesequence);
            if (!correctnote)
            {
                //Play wrong sound

                //Reset sequence
                currentsequence = new List<string>();
            } else if (currentsequence.Count == notesequence.Count)
            {
                //Play correct sound
                GetComponent<AudioSource>().Play();

                //Reset sequence
                currentsequence = new List<string>();
            }
        }
    }

    public bool CheckIfHighlighted(string note)
    {
        if (notesequence.Count == currentsequence.Count) return false;

        string correctnote = notesequence[currentsequence.Count];
        return correctnote.Equals(note);
    }
}

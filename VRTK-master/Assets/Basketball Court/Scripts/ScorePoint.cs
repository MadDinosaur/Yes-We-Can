using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScorePoint : MonoBehaviour
{
    int points;
    float timer;
    public ParticleSystem confetti;
    public TMP_Text textBox;
    public TMP_Text timeBox;
    public Animator peopleAnimator;
    System.Random rnd = new System.Random();
    
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        string minutes = Math.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");

        timeBox.SetText(string.Format("{0}:{1}", minutes, seconds));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Basketball"))
        {
            points += 1;
            confetti.Play();
            textBox.SetText(points.ToString());
            peopleAnimator.SetInteger("AnimationNum", rnd.Next(1, 4));
            peopleAnimator.SetInteger("AnimationNum", 0);
        }
    }
}

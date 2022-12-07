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

    public List<Animator> allCharacters = new List<Animator>();
    
    // Start is called before the first frame update
    void Start()
    {
        points = 0;

        foreach (Animator item in FindObjectsOfType<Animator>())
        {
            if (item.runtimeAnimatorController.name == "People Controller")
            {
                allCharacters.Add(item);
            }
        }
        

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

            foreach (var character in allCharacters)
            {
                AssignAnimation(character);
            }

        }
    }

    public void AssignAnimation(Animator cc)
    {
        cc.SetInteger("AnimationNum", rnd.Next(1, 4));
        cc.SetTrigger("Cheer");
    }
}

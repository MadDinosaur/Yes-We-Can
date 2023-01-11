using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class ScorePoint : MonoBehaviour
{
    int points;
    float timer;
    public ParticleSystem confetti;
    public TMP_Text textBox;
    public TMP_Text timeBox;
    public Animator[] peopleAnimators = new Animator[9];
    public AnimatorControllerParameter animator;
    public ScoreEvent onScored;
    //System.Random rnd = new System.Random();

    [Serializable]
    public class ScoreEvent : UnityEvent { }

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
            GetComponent<AudioSource>().Play();
            textBox.SetText(points.ToString());
            foreach(Animator peopleAnimator in peopleAnimators) {
                peopleAnimator.SetTrigger("Cheer");
                peopleAnimator.SetInteger("AnimationNum", UnityEngine.Random.Range(1, 4));
            }
            onScored.Invoke();
        }
    }
}

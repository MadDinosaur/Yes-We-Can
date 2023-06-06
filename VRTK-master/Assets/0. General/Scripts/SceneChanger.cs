﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System;
using TMPro;

public class SceneChanger : MonoBehaviour
{
    public UnityEvent onSceneLoad;

    public bool fadeOnStart = true;
    public float transitionDuration = 2;
    public Color transitionColor;
    public GameObject screenFader;
    private Renderer rend;

    static GameMode gameMode;
    static bool isInterviewOnly;
    static bool playVideoOnStart;
    static bool enableObjectsOnStart;
    bool mainMenuTriggered;
    bool movieLoadTriggered;
    bool basketballLoadTriggered;
    bool musicRoomLoadTriggered;
    bool classroomLoadTriggered;

    [SerializeField]
    public VideoClip[] videoClips = new VideoClip[3];
    [SerializeField]
    public GameObject[] characterObjects = new GameObject[3];
    enum GameMode
    {
        Wheelchair,
        Blindess,
        Dyslexia,
        None
    }
    // Start is called before the first frame update
    void Start()
    {
        //Invoke teleport event
        onSceneLoad.Invoke();

        //Fade effect
        rend = screenFader.GetComponent<Renderer>();
        if (fadeOnStart) FadeIn();

        //Choose video playing in movie theatre
        if (playVideoOnStart)
        {
            //Get video player object and set the correct video for each character
            VideoPlayer videoPlayer = GameObject.FindGameObjectWithTag("MovieScreen").GetComponent<VideoPlayer>();
            switch (gameMode)
            {
                case (GameMode.Wheelchair):
                    videoPlayer.clip = videoClips[0];
                    break;
                case (GameMode.Blindess):
                    videoPlayer.clip = videoClips[1];
                    break;
                case (GameMode.Dyslexia):
                    videoPlayer.clip = videoClips[2];
                    break;
                default:
                    break;
            }
            playVideoOnStart = false;
        }

        //Choose which character to active in entrance
        if (enableObjectsOnStart)
        {
            //Searches for character section and enables it
            switch (gameMode)
            {
                case (GameMode.Wheelchair):
                    characterObjects[0].SetActive(true);
                    characterObjects[1].SetActive(false);
                    characterObjects[2].SetActive(false);
                    break;
                case (GameMode.Blindess):
                    characterObjects[0].SetActive(false);
                    characterObjects[1].SetActive(true);
                    characterObjects[2].SetActive(false);
                    break;
                case (GameMode.Dyslexia):
                    characterObjects[0].SetActive(false);
                    characterObjects[1].SetActive(false);
                    characterObjects[2].SetActive(true);
                    break;
                default:
                    break;
            }
            enableObjectsOnStart = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (movieLoadTriggered) return;

        if (other.gameObject.tag.Equals("Headset"))
        {
            movieLoadTriggered = true;
            LeaveMovieTheater();
        }
    }

    public void GoToMainMenu()
    {
        if (mainMenuTriggered) return;

        mainMenuTriggered = true;
        resetMenuOptions();
        LoadScene(1);
    }

    public void SetLukasGameMode()
    {
        gameMode = GameMode.Wheelchair;
    }

    public void SetTheresaGameMode()
    {
        gameMode = GameMode.Blindess;
    }

    public void SetSaraGameMode()
    {
        gameMode = GameMode.Dyslexia;
    }

    public void SetInterviewOnlyGameMode()
    {
        isInterviewOnly = true;
    }

    public void GoToMovieTheater()
    {
        mainMenuTriggered = false;
        playVideoOnStart = true;
        LoadScene(2);
    }

    public void LeaveMovieTheater()
    {
        playVideoOnStart = false;
        if (isInterviewOnly) GoToMainMenu();
        else
        {
            enableObjectsOnStart = true;
            GoToFHEntrance();
        }
    }

    public void GoToFHEntrance()
    {
        LoadScene(3);
    }

    public void LeaveFHEntrance()
    {
        switch (gameMode)
        {
            case (GameMode.Wheelchair):
                GoToBasketballCourt();
                break;
            case (GameMode.Blindess):
                GoToMusicRoom();
                break;
            case (GameMode.Dyslexia):
                GoToPuzzleRoom();
                break;
        }
    }

    public void GoToBasketballCourt()
    {
        if (basketballLoadTriggered) return;

        mainMenuTriggered = false;
        basketballLoadTriggered = true;
        LoadScene(4);
    }

    public void GoToMusicRoom()
    {
        if (musicRoomLoadTriggered) return;

        mainMenuTriggered = false;
        musicRoomLoadTriggered = true;
        LoadScene(5);
    }

    public void GoToPuzzleRoom()
    {
        if (classroomLoadTriggered) return;

        mainMenuTriggered = false;
        classroomLoadTriggered = true;
        LoadScene(6);
    }

    void resetMenuOptions()
    {
        isInterviewOnly = false;
        gameMode = GameMode.None;

        movieLoadTriggered = false;
        basketballLoadTriggered = false;
        musicRoomLoadTriggered = false;
        classroomLoadTriggered = false;
    }

    void LoadScene(int index)
    {
        StartCoroutine(LoadSceneAsync(index));
    }

    IEnumerator LoadSceneAsync(int index)
    {
        FadeOut();

        //Launch new scene
        AsyncOperation operation = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);

        //Wait for scene load and trasition animation
        operation.allowSceneActivation = false;

        float timer = 0;
        while (timer <= transitionDuration && !operation.isDone)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        operation.allowSceneActivation = true;
    }

    public void FadeIn()
    {
        Fade(1, 0);
    }

    public void FadeOut()
    {
        Fade(0, 1);
    }

    void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer <= transitionDuration)
        {
            Color newColor = transitionColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / transitionDuration);

            rend.material.SetColor("_BaseColor", newColor);

            timer += Time.deltaTime;
            yield return null;
        }

        Color newColorFinal = transitionColor;
        newColorFinal.a = alphaOut;

        rend.material.SetColor("_Color", newColorFinal);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
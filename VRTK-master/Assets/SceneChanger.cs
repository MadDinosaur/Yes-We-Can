using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float transitionDuration = 2;
    public Color transitionColor;
    public GameObject screenFader;
    private Renderer rend;
    //public GameObject LoadingScreen, LoadingBarFill;
    
    static GameMode gameMode;
    static bool isInterviewOnly;
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
        rend = screenFader.GetComponent<Renderer>();
        if (fadeOnStart) FadeIn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Headset"))
        {
            LeaveMovieTheater();
        }
    }

    public void GoToMainMenu()
    {
        Debug.Log("Going back to main menu...");
        resetMenuOptions();
        SceneManager.LoadScene("MenuClass");
    }

    public void SetLukasGameMode()
    {
        Debug.Log("lukas");
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
        Debug.Log("movie");
        SceneManager.LoadScene("MovieTheatre");
    }

    public void LeaveMovieTheater()
    {
        if (isInterviewOnly) GoToMainMenu();
        else SceneManager.LoadScene("FHEntr");
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
        SceneManager.LoadScene("BasketballCourt");
    }

    public void GoToMusicRoom()
    {
        SceneManager.LoadScene("AudioRoom");
    }

    public void GoToPuzzleRoom()
    {
        SceneManager.LoadScene("Classroom");
    }

    void resetMenuOptions()
    {
        isInterviewOnly = false;
        gameMode = GameMode.None;
    }

    IEnumerator LoadSceneAsync(string name)
    {
        FadeOut();
        
        //Launch new scene
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);

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

    void Fade (float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    IEnumerator FadeRoutine (float alphaIn, float alphaOut)
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
}

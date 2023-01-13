using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneChanger : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float transitionDuration = 2;
    public Color transitionColor;
    public GameObject screenFader;
    private Renderer rend;
    
    static GameMode gameMode;
    static bool isInterviewOnly;
    static bool playVideoOnStart;
    static bool enableObjectsOnStart;

    [SerializeField]
    public VideoClip[] videoClips = new VideoClip[3];
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

        if (enableObjectsOnStart)
        {
            //Searches for character section and enables it
            switch (gameMode)
            {
                case (GameMode.Wheelchair):
                    GameObject.Find("LUKAS").SetActive(true);
                    GameObject.Find("SARA").SetActive(false);
                    GameObject.Find("THERESA").SetActive(false);
                    break;
                case (GameMode.Blindess):
                    GameObject.Find("LUKAS").SetActive(false);
                    GameObject.Find("SARA").SetActive(false);
                    GameObject.Find("THERESA").SetActive(true);
                    break;
                case (GameMode.Dyslexia):
                    GameObject.Find("LUKAS").SetActive(false);
                    GameObject.Find("SARA").SetActive(true);
                    GameObject.Find("THERESA").SetActive(false);
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
        Debug.Log("triger with " + other.gameObject.name);
        if (other.gameObject.tag.Equals("Headset"))
        {
            LeaveMovieTheater();
        }
    }

    public void GoToMainMenu()
    {
        Debug.Log("Going back to main menu...");
        resetMenuOptions();
        LoadScene("MenuClass");
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
        playVideoOnStart = true;
        LoadScene("MovieTheatre");
    }

    public void LeaveMovieTheater()
    {
        playVideoOnStart = false;
        if (isInterviewOnly) GoToMainMenu();
        else
        {
            enableObjectsOnStart = true;
            LoadScene("FHEntr");
        }
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
        LoadScene("BasketballCourt");
    }

    public void GoToMusicRoom()
    {
        LoadScene("AudioRoom");
    }

    public void GoToPuzzleRoom()
    {
        LoadScene("Classroom");
    }

    void resetMenuOptions()
    {
        isInterviewOnly = false;
        gameMode = GameMode.None;
    }

    void LoadScene(string name)
    {
        StartCoroutine(LoadSceneAsync(name));
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

    public void Quit()
    {
        Application.Quit();
    }
}

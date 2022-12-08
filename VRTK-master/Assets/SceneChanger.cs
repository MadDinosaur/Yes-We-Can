using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag.Equals("Headset"))
        {
            LeaveMovieTheater();
        }
    }

    public void GoToMainMenu()
    {
        resetMenuOptions();
        SceneManager.LoadScene("Menu");
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
        SceneManager.LoadScene("MovieTheatre");
    }

    public void LeaveMovieTheater()
    {
        if (isInterviewOnly) GoToMainMenu();
        else SceneManager.LoadScene("FHEntr");
    }

    public void LeaveFHEntrance()
    {
        switch(gameMode)
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
}

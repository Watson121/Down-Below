using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {

    private GameObject Player;
    private PausedMenu PausedMenuPlayer;
    private string LevelToLoad;
    private AsyncOperation Scene;
    public GameObject LoadingText;

    public Button ResumeGame;
    public Button QuitGameButton;

    // Use this for initialization
    void Start ()
    {
        Player = GameObject.Find("Player");
        PausedMenuPlayer = Player.GetComponent<PausedMenu>();
        LoadingText = GameObject.Find("LoadingText");
        LevelToLoad = "MainMenu";
        //LoadingText.SetActive(false);
    }

    void OnEnable()
    {
        ResumeGame.onClick.AddListener(delegate { CloseMenu(); });
        QuitGameButton.onClick.AddListener(delegate { QuitGame(); });
    }

    void CloseMenu()
    {
        PausedMenuPlayer.CloseMenu();
    }

    void QuitGame()
    {
        Scene = SceneManager.LoadSceneAsync(LevelToLoad, LoadSceneMode.Single);
        if (Scene.progress !=0.9)
        {
            LoadingText.SetActive(true);
        }
    }
}

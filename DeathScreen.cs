using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour {

    private GameObject Player;
    public GameObject LoadingText;
    public GameObject DeathMenu;

    private string LevelToLoad;
    private Scene CurrentLevel;
    private AsyncOperation Scene;

    public PlayerDeath PlayerDeathScript;

    public Button TryAgainButton;
    public Button QuitGameButton;


    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        LoadingText = GameObject.Find("LoadingText");
        DeathMenu = GameObject.Find("Game Over Menu");

        LevelToLoad = "MainMenu";
        CurrentLevel = SceneManager.GetActiveScene();

        PlayerDeathScript = Player.GetComponent<PlayerDeath>();

        LoadingText.SetActive(false);
    }

    void OnEnable()
    {
        TryAgainButton.onClick.AddListener(delegate { TryAgain(); });
        QuitGameButton.onClick.AddListener(delegate { QuitGame(); });
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerDeathScript.PlayerIsDead() == false)
        {
            DeathMenu.SetActive(false);
        }
        else if (PlayerDeathScript.PlayerIsDead() == true)
        {
            DeathMenu.SetActive(true);
        }
    }

    void TryAgain()
    {
        SceneManager.LoadScene(CurrentLevel.buildIndex);
        PlayerDeathScript.PlayerDeadFalse();
        if (Scene.progress != 0.9)
        {
            LoadingText.SetActive(true);
        }
    }

    void QuitGame()
    {
        Scene = SceneManager.LoadSceneAsync(LevelToLoad, LoadSceneMode.Single);
        PlayerDeathScript.PlayerDeadFalse();
        if (Scene.progress != 0.9)
        {
            LoadingText.SetActive(true);
        }
    }
}

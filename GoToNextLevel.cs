using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GoToNextLevel : MonoBehaviour {

    private string LastLevel;
    private string CurrentLevel;
    private string LevelStatsLevel;
    private string NextLevel;
    int levelNum;
    CurrentLevel currentLevel;
    GameObject levelNumObject;

	// Use this for initialization
	void Start ()
    {
        levelNumObject = GameObject.Find("LevelNum");
        currentLevel = levelNumObject.GetComponent<CurrentLevel>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        levelNum = currentLevel.CurrentLevelNum();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(levelNum == 0)
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Entrance"));
                SceneManager.LoadScene("Level One", LoadSceneMode.Additive);
                currentLevel.IncreaseLevel();
                Destroy(this.gameObject);
            }else if(levelNum == 1)
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Level One"));
                SceneManager.LoadScene("Level Two", LoadSceneMode.Additive);
                currentLevel.IncreaseLevel();
                Destroy(this.gameObject);
            }
        }
    }
}

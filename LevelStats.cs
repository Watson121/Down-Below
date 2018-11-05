using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelStats : MonoBehaviour {

    //Level Name
    public string CurrentLevel;

    [System.Serializable]
    public class LevelOneStats
    {
        [Header("Level One")]
        public int NumberOfCollectalbesCollected;
        public bool AllCollectablesCollected;
        public float Timer;

        public void Start()
        {
            NumberOfCollectalbesCollected = 0;
            NumberOfCollectalbesCollected = PlayerPrefs.GetInt("Level One Collectables", NumberOfCollectalbesCollected);

            Timer = 0;
            Timer = PlayerPrefs.GetFloat("Time For Level One", Timer);

            Update();
        }
        public void Update()
        {
            if (NumberOfCollectalbesCollected == 1)
            {
                AllCollectablesCollected = true;
            }
            else
            {
                AllCollectablesCollected = false;
            }
            LevelOne();
        }
        public void LevelOne()
        {
            if (AllCollectablesCollected == false)
            {
                print("Got the collectable");
                NumberOfCollectalbesCollected = NumberOfCollectalbesCollected + 1;
                PlayerPrefs.SetInt("Level One Collectables", NumberOfCollectalbesCollected);
            }
        }
    }

    public LevelOneStats LevelOneClass;
    
	// Use this for initialization
	void Start ()
    {
        CurrentLevel = SceneManager.GetActiveScene().name;
    }
	
	// Update is called once per frame
	void Update () {
		//Calculating Time
        if(CurrentLevel == "Test")
        {
            LevelOneClass.Timer += Time.deltaTime;
            PlayerPrefs.SetFloat("Time For Level One", LevelOneClass.Timer);
        }
	}
}

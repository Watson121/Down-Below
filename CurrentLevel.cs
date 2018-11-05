using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLevel : MonoBehaviour {

    int currentLevel;


	// Use this for initialization
	void Start () {
        currentLevel = 0;
	}
	
    public int CurrentLevelNum()
    {
        return currentLevel;
    }

    public void IncreaseLevel()
    {
        currentLevel = currentLevel + 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorClosing : MonoBehaviour {

    #region Declerations

    #region Game Objects
    GameObject currentDoor;
    Transform upTo;
    #endregion

    #region Level Num
    int levelNum;
    string levelName;
    GameObject levelNumObject;
    CurrentLevel currentLevel;
    #endregion

    float speed;
    bool openTrue;

    #endregion

    // Use this for initialization
    void Start()
    {
        currentDoor = this.gameObject;
        upTo = currentDoor.transform.GetChild(0);
        openTrue = false;
        speed = 0.5f * Time.deltaTime;

        levelNumObject = GameObject.Find("LevelNum");
        currentLevel = levelNumObject.GetComponent<CurrentLevel>();
    }
    void Update()
    {
        levelNum = currentLevel.CurrentLevelNum();

        //if (levelNum == 0)
        //{
        //    levelName = "Entrance";
        //}else if(levelNum == 1)
        //{
        //    levelName = "Level One";
        //}

        if (openTrue == true)
        {
            Open();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(openTime());
        }
    }

    void Open()
    {
        currentDoor.transform.position = Vector3.MoveTowards(transform.position, upTo.position, speed);
    }

    IEnumerator openTime()
    {
        yield return new WaitForSeconds(1f);
        openTrue = true;
        StartCoroutine(stopTime());
    }

    IEnumerator stopTime()
    {
        yield return new WaitForSeconds(7.95f);
        openTrue = false;
    }
}

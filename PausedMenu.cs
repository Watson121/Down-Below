using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PausedMenu : MonoBehaviour {

    #region Declerations

    #region GameObjects
    GameObject Player;
    GameObject PauseMenu;
	GameObject mainCamera;
    #endregion

    #region Components
    PlayerMovement PlayerMovementScript;
    PlayerAudio PlayerAudioMovementScript;
    Rigidbody PlayerRigidbody;
    #endregion

    bool pause;
    #endregion

    // Use this for initialization
    void Start ()
    {
        Player = GameObject.Find("Player");
        PauseMenu = GameObject.Find("Pause Menu");

        PlayerMovementScript = Player.GetComponent<PlayerMovement>();
        PlayerAudioMovementScript = Player.GetComponent<PlayerAudio>();
        PlayerRigidbody = Player.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P))
        {
            pause = !pause;
        }
        if (pause == true)
        {
            PauseMenu.SetActive(true);
            PlayerMovementScript.enabled = false;
            PlayerAudioMovementScript.enabled = false;
            PlayerRigidbody.isKinematic = true;
        }
        else if (pause == false)
        {
            PauseMenu.SetActive(false);
            PlayerMovementScript.enabled = true;
            PlayerAudioMovementScript.enabled = true;
            PlayerRigidbody.isKinematic = false;
        }
    }

    public void CloseMenu()
    {
        pause = false;
    }

    public bool Pause()
    {
        return pause;
    }
}

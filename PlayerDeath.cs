using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerDeath : MonoBehaviour {

    [SerializeField]
    bool playerIsDead;
    PlayerMovement PlayerMovementScript;

    void Start()
    {
        PlayerMovementScript = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsDead == true)
        {
            PlayerMovementScript.enabled = false;
        }
    }

    public bool PlayerIsDead()
    {
        return playerIsDead;
    }

    public void PlayerDeadFalse()
    {
        playerIsDead = false;
    }

    public void PlayerDeadTrue()
    {
        playerIsDead = true;
    }

}

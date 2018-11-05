using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {

    public GameObject Player;
    public GameObject LavaObject;
    public Rigidbody PlayerRigidbody;

    public PlayerDeath PlayerDeathScript;

	void Start ()
    {
        Player = GameObject.Find("Player");
        PlayerRigidbody = Player.GetComponent<Rigidbody>();
        PlayerDeathScript = Player.GetComponent<PlayerDeath>();
        LavaObject = this.gameObject;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerRigidbody.isKinematic = true;
            PlayerRigidbody.useGravity = false;
            PlayerDeathScript.PlayerDeadTrue();
        }
    }
}

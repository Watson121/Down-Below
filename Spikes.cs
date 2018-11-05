using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    public GameObject Player;
    public GameObject SpikeObjects;

	// Use this for initialization
	void Start ()
    {
        Player = GameObject.Find("Player");
        SpikeObjects = this.gameObject;
	}
	
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(Player);
        }
    }
}

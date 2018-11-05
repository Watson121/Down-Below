using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisFall : MonoBehaviour {

    GameObject debris, sceneSettings, planes;

	// Use this for initialization
	void Start () {

        debris = GameObject.Find("DebrisPile");
        planes = GameObject.Find("Planes");
        sceneSettings = GameObject.Find("SceneSettings");
        debris.SetActive(false);
	}
	
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            debris.SetActive(true);
            planes.SetActive(false);
            sceneSettings.SetActive(false);
        }
    }


}

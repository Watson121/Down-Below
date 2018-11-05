using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnTrigger : MonoBehaviour {

    GameObject lightObject;
    Animator lightAnimator;

	// Use this for initialization
	void Start () {
        lightObject = this.gameObject;
        lightAnimator = lightObject.GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            lightAnimator.SetBool("TorchOn", true);
        }
    }

}

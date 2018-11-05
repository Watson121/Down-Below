using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public Rigidbody Test;
    public Transform ShootingEnd;
    public bool CanFire;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (CanFire == true)
        {
            Rigidbody ShooterInstance;
            ShooterInstance = Instantiate(Test, ShootingEnd.position, ShootingEnd.rotation) as Rigidbody;
            ShooterInstance.AddForce(ShootingEnd.forward * 5000);
            CanFire = false;
        }
	}
}

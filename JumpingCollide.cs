using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingCollide : MonoBehaviour {

    public bool Grounded;


    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Floor")
        {
            Grounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Floor")
        {
            Grounded = false;
        }
    }



}

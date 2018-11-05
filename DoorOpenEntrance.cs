using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenEntrance : MonoBehaviour {

    GameObject currentDoor;
    Transform upTo;
    float speed;
    bool openTrue;

    // Use this for initialization
    void Start () {
        currentDoor = this.gameObject;
        upTo = currentDoor.transform.GetChild(0);
        openTrue = false;
        speed = 0.5f * Time.deltaTime;
        //Open();
    }
    void Update()
    {


        if (openTrue == true)
        {
            Close();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(openTime());
        }
    }

    void Close()
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
        yield return new WaitForSeconds(7.2f);
        openTrue = false;
    }

}

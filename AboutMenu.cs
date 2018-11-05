using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutMenu : MonoBehaviour {
    private GameObject MainCamera;
    //Text
    private GameObject AboutText;
    private GameObject CreditsText;
    //Components
    private Animator CameraAnimator;
    public AnimationClip ReturnToCenter;

	void Start () {
        AboutText = GameObject.Find("About Game");
        CreditsText = GameObject.Find("Credits");
        MainCamera = GameObject.Find("Main Camera");
        CameraAnimator = MainCamera.GetComponent<Animator>();

        AboutText.SetActive(true);
        CreditsText.SetActive(false);
    }

    public void About()
    {
        AboutText.SetActive(true);
        CreditsText.SetActive(false);
    }

    public void Credit()
    {
        AboutText.SetActive(false);
        CreditsText.SetActive(true);
    }
    public void Back()
    {
        CameraAnimator.SetBool("MoveToCenter", true);
        StartCoroutine(MoveToCenter());
    }
    IEnumerator MoveToCenter()
    {
        yield return new WaitForSeconds(1.01f);
        CameraAnimator.SetBool("MoveToCenter", false);
    }
}

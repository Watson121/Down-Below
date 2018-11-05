using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    public string LevelToLoad;

    public Transform MainCamera;
    public GameObject LoadingText;

    private Animator CameraAnimator;
    private AsyncOperation Scene;
    public AnimationClip Right;
    public AnimationClip Left;
    public AnimationClip Up;

	// Use this for initialization
	void Start ()
    {
        MainCamera = GameObject.Find("Main Camera").transform;
        LoadingText = GameObject.Find("LoadingText");

        CameraAnimator = MainCamera.GetComponent<Animator>();
        LoadingText.SetActive(false);
    }
    public void StartGame()
    {
        LevelToLoad = "Level One";
        Scene = SceneManager.LoadSceneAsync(LevelToLoad, LoadSceneMode.Single);

        if(Scene.progress != 0.9)
        {
            LoadingText.SetActive(true);
        }

        print("Start");
    }

    public void Options()
    {
        print("Options");
        CameraAnimator.SetBool("MoveToLeft", true);
        StartCoroutine(LeftTime());
    }

    public void About()
    {
        print("About");
        CameraAnimator.SetBool("MoveToRight", true);
        StartCoroutine(RightTime());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator RightTime()
    {
        yield return new WaitForSeconds(Right.length);
        CameraAnimator.SetBool("MoveToRight", false);
    }
    IEnumerator LeftTime()
    {
        yield return new WaitForSeconds(Left.length);
        CameraAnimator.SetBool("MoveToLeft", false);
    }
    IEnumerator UpTime()
    {
        yield return new WaitForSeconds(Up.length);
        CameraAnimator.SetBool("MoveUp", false);
    }
    IEnumerator LoadingLevel()
    {
        yield return new WaitForSeconds(1);

        while (!Scene.isDone)
        {
        }
    }
}

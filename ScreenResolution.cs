using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*This code changes the resolution in the Canvas Scaler dynamicaly
 * 
 * */



public class ScreenResolution : MonoBehaviour {

    public int Width;
    public int Height;
    private GameObject CanvasObject;
    private CanvasScaler Canvas;

	// Use this for initialization
	void Start ()
    {
        CanvasObject = this.gameObject;
        Canvas = CanvasObject.GetComponent<CanvasScaler>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Width = Screen.width;
        Height = Screen.height;

        Canvas.referenceResolution = new Vector2(Width, Height);
    }
}

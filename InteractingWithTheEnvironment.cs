using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractingWithTheEnvironment : MonoBehaviour {

	Transform cameraObject;
    [SerializeField]
	GameObject interactableObject;
    [SerializeField]
    GoldCollectable goldCollectable;

	// Use this for initialization
	void Start () {

		cameraObject = this.gameObject.transform;

	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		Ray lookingRay = new Ray(cameraObject.position, cameraObject.forward);

		Debug.DrawRay(cameraObject.position, cameraObject.forward, Color.green);

		if (Physics.Raycast (lookingRay, out hit, 4)) {
			if (hit.collider.tag == "Collectable") {

                interactableObject = hit.collider.gameObject;
                goldCollectable = interactableObject.GetComponent<GoldCollectable>();
                goldCollectable.CollectableSelectedTrue();

                if (Input.GetButtonDown ("Interact")) {
                    goldCollectable.collectObject();
                }
            }
            else
            {
                if (interactableObject != null)
                {
                    goldCollectable.CollectableSelectedFalse();
                }
                interactableObject = null;
                goldCollectable = null;
            }
		}
	}
}

using UnityEngine;
using System.Collections;

public class TriggerPickUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	// on trigger enter only happens first time it touches the trigger 
	void OnTriggerEnter(Collider activator) {

		if (activator.tag == "flammable") {
			// check tag 

			activator.transform.SetParent( transform ); // it's parenting 2 things together 
		}


	}
}

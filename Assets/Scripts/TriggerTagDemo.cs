using UnityEngine;
using System.Collections;

public class TriggerTagDemo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter ( Collider activator ) { // activator is the thing entering the trigger
		if (activator.tag == "Player") {
			// add health, do nothing, etc. 
			Debug.Log ("I'm doing nothing");

		} else if (activator.tag == "flammable") {
			Destroy (activator.gameObject); // destroy flammable thing
		}

	}

	void OnTriggerStay ( Collider activator ) { // activator is the thing entering the trigger
		if (activator.tag == "Player") {
			// add health, do nothing, etc. 
			activator.transform.Translate (0f,0.1f,0f);
			
		} else if (activator.tag == "flammable") {
			Destroy (activator.gameObject); // destroy flammable thing
		}
		
	}
}

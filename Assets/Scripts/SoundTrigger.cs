using UnityEngine;
using System.Collections;

public class SoundTrigger : MonoBehaviour {

	public AudioSource mySound;


	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			mySound.Play ();
		}
	}

	// you can also say 
	//if (mySound.isPlaying == false) 
	//mySound.Stop();


	/*
	void OnTriggerEnter() {
		mySound.Play () 
	} */
}

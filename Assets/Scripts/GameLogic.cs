using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {
	
	public Transform yogaMat;
	//public Transform startingPoint; 
	//public GameObject player;

	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

		
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "feet") {
			// this means food has hit this collider
			//send message to game manager
			Application.LoadLevel("3dPrototype");
		}

	}
}
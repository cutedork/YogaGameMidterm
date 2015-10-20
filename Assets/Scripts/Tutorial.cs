using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	public Text tutorialText;

	
	public int tutorialState;
	public int counter; 



	// Use this for initialization
	void Start () {

		//counter = 0; 
	
		tutorialState = 0;
		counter = 0;

	}
	
	// Update is called once per frame
	void Update () {

		TutorialGuide ();
	

	
	}

	void TutorialGuide() {

		switch(tutorialState) 
		{
		case 0: 
			tutorialText.text = "Hello! I'm gonna teach you about your body. Press space to continue.";
			if (Input.GetKeyDown (KeyCode.Space)) {
				tutorialState = 1; 
			}
			break;

		case 1: 
			tutorialText.text = "Good! Press E to move your left arm.";
			if (Input.GetKeyDown (KeyCode.E)) {
				counter++;
			}

			if (counter > 3) {
				tutorialState = 2;
				counter = 0;
			}

			break;

		case 2: 
			tutorialText.text = "Fantastic. Press I to move your right arm."; 
			if (Input.GetKeyDown (KeyCode.I)) {
				counter++;
			}
			
			if (counter > 3) {
				tutorialState = 3;
				counter = 0;
			}
			break; 

		case 3: 
			tutorialText.text = "Wonderful. Press F to move your left leg.";
			if (Input.GetKeyDown (KeyCode.F)) {
				counter++;
			}
			
			if (counter > 3) {
				tutorialState = 4;
				counter = 0;
			}
			break; 

		case 4: 
			tutorialText.text = "Almost done! Press J to move you right leg."; 
			if (Input.GetKeyDown (KeyCode.J)) {
				counter++;
			}
			
			if (counter > 3) {
				tutorialState = 5;
				counter = 0;
			}
			break; 

		case 5: 
			tutorialText.text = "Alright, make sure you copy my pose before the timer runs out. When you're ready, press space and we'll begin class.";
			if (Input.GetKeyDown (KeyCode.Space)) {
				Application.LoadLevel ("3dPrototype");
			}

		
			break;
	
		

		}

	}





}

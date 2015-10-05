using UnityEngine;
using System.Collections;

public class ChangeLimbs : MonoBehaviour {

	public GameObject body; 

	//left arm
	public GameObject leftArmDown;
	public GameObject leftArmUp;
	public GameObject leftArmOut;

 	private int leftArmState; 
	public int LeftArmState {
		get { return leftArmState; } 
	}

	// right arm
	public GameObject rightArmDown;
	public GameObject rightArmUp;
	public GameObject rightArmOut;

	private int rightArmState;
	public int RightArmState {
		get { return rightArmState; } 
	}

	// left leg
	public GameObject leftLegDown;
	public GameObject leftLegOut;

	private int leftLegState;
	public int LeftLegState {
		get { return leftLegState; } 
	}

	// right leg
	public GameObject rightLegDown;
	public GameObject rightLegOut;

	private int rightLegState;
	public int RightLegState {
		get { return rightLegState; } 
	}


	// Use this for initialization
	void Start () {

		leftArmDown.SetActive(true); 
		leftArmState = 1;

		rightArmDown.SetActive(true);
		rightArmState = 1;

		leftLegDown.SetActive (true);
		leftLegState = 1;

		rightLegDown.SetActive (true);
		rightLegState = 1;
	}
	
	// Update is called once per frame
	void Update () {

		// press D to change left arm 

		if (Input.GetKeyDown(KeyCode.F)) { 
			// check mode

			leftArmState++;
			
			if (leftArmState > 2) {
				leftArmState = 0;
			}

			if (leftArmState == 0){
				leftArmDown.SetActive(false);
				leftArmOut.SetActive(false);
				leftArmUp.SetActive(true);
			} else if (leftArmState == 1){
				leftArmUp.SetActive(false);
				leftArmOut.SetActive(false);
				leftArmDown.SetActive(true);
			} else if (leftArmState == 2){
				leftArmDown.SetActive(false);
				leftArmUp.SetActive(false);
				leftArmOut.SetActive(true);

			}


		}

		// press F to change right arm 
		if (Input.GetKeyDown (KeyCode.J)) {
			rightArmState++;
			if (rightArmState > 2) {
				rightArmState = 0;
			}

			if (rightArmState == 0) {
				rightArmDown.SetActive(false);
				rightArmOut.SetActive (false);
				rightArmUp.SetActive (true);

			} else if (rightArmState == 1) {
				rightArmUp.SetActive(false);
				rightArmOut.SetActive (false);
				rightArmDown.SetActive(true);
			} else if (rightArmState == 2) {
				rightArmDown.SetActive (false);
				rightArmUp.SetActive (false);
				rightArmOut.SetActive (true);
			}



		}
		// press J to change left leg 

		if (Input.GetKeyDown (KeyCode.D)) {

			leftLegState++;
			if (leftLegState > 1) {
				leftLegState = 0;
			}


			if (leftLegState == 0) {
				leftLegDown.SetActive(false);
				leftLegOut.SetActive (true);
				
			} else if (leftLegState == 1) {
				leftLegDown.SetActive(true);
				leftLegOut.SetActive (false);
			}
			

		}	

		// press K to change right leg
		  
		if (Input.GetKeyDown (KeyCode.K)) {
			rightLegState++;
			if (rightLegState > 1) {
				rightLegState = 0;
			}

			if (rightLegState == 0) {
				rightLegDown.SetActive(false);
				rightLegOut.SetActive (true);
				
			} else if (rightLegState == 1) {
				rightLegDown.SetActive(true);
				rightLegOut.SetActive (false);
			}
			

			
		}
	}
}

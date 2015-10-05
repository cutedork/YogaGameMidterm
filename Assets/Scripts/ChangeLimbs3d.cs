using UnityEngine;
using System.Collections;

public class ChangeLimbs3d : MonoBehaviour {

	public float turnSpeed = 10f;
	
	//limbs
	public GameObject leftArm;
	Quaternion leftArmTargetRotation;

	public GameObject rightArm; 
	Quaternion rightArmTargetRotation;

	public GameObject leftLeg;
	Quaternion leftLegTargetRotation;

	public GameObject rightLeg;
	Quaternion rightLegTargetRotation;

	// limb states
	private int leftArmState;  
	public int LeftArmState {
		get { return leftArmState; }
	}

	private int rightArmState;
	public int RightArmState {
		get { return rightArmState; }
	}

	private int leftLegState;
	public int LeftLegState {
		get { return leftLegState; }
	}

	private int rightLegState;
	public int RightLegState {
		get { return rightLegState; } 
	}
	
	
	// Use this for initialization
	void Start () {

		//leftArm.transform.eulerAngles = new Vector3(0f, 0f, 90f); 
		leftArmTargetRotation = Quaternion.Euler(0f, 0f, 90f); 
		leftArmState = 1;

		//rightArm.transform.eulerAngles = new Vector3(0f, 0f, -90f);
		rightArmTargetRotation = Quaternion.Euler(0f, 0f, -90f); 
		rightArmState = 1;

		//leftLeg.transform.eulerAngles = new Vector3(0f, 0f, 0f);
		leftLegTargetRotation = Quaternion.Euler(0f, 0f, 0f);
		leftLegState = 1;

		//rightLeg.transform.eulerAngles = new Vector3 (0f, 0f, 0f);
		rightLegTargetRotation = Quaternion.Euler(0f, 0f, 0f);
		rightLegState = 1;
		/*
		
		leftArmDown.SetActive(true); 
		leftArmState = 1;
		
		rightArmDown.SetActive(true);
		rightArmState = 1;
		
		leftLegDown.SetActive (true);
		leftLegState = 1;
		
		rightLegDown.SetActive (true);
		rightLegState = 1;
		*/
	}
	
	// Update is called once per frame
	void Update () {

		// all current rotations for limbs
		Quaternion currentLeftArmRotation = leftArm.transform.rotation; 
		Quaternion currentRightArmRotation = rightArm.transform.rotation;
		Quaternion currentLeftLegRotation = leftLeg.transform.rotation;
		Quaternion currentRightLegRotation = rightLeg.transform.rotation;
		
		// press D to change left arm 
		
		if (Input.GetKeyDown(KeyCode.F)) { 

			leftArmState++;
			if (leftArmState > 2) {
				leftArmState = 0;
			}

			if (leftArmState == 0) {
				//leftArm.transform.eulerAngles = new Vector3(0f, 0f, -90f); // arm up
				leftArmTargetRotation = Quaternion.Euler(0f, 0f, -90f);
			} else if (leftArmState == 1) {
				//leftArm.transform.eulerAngles = new Vector3(0f, 0f, 90f); // arm down 
				leftArmTargetRotation = Quaternion.Euler(0f, 0f, 90f);
			} else if (leftArmState == 2) {
				//leftArm.transform.eulerAngles = new Vector3(0f, 0f, 0f); // arm out 
				leftArmTargetRotation = Quaternion.Euler(0f, 0f, 0f);
			}

			
			
		}
		
		// press F to change right arm 
		if (Input.GetKeyDown (KeyCode.J)) {

			rightArmState++;
			if (rightArmState > 2) {
				rightArmState = 0;
			}
			if (rightArmState == 0) {
				//rightArm.transform.eulerAngles = new Vector3(0f, 0f, 90f); // arm up
				rightArmTargetRotation = Quaternion.Euler(0f, 0f, 90f);
			} else if (rightArmState == 1) {
				//rightArm.transform.eulerAngles = new Vector3(0f, 0f, -90f); // arm down 
				rightArmTargetRotation = Quaternion.Euler(0f, 0f, -90f);
			} else if (rightArmState == 2) {
				//rightArm.transform.eulerAngles = new Vector3(0f, 0f, 0f); // arm out 
				rightArmTargetRotation = Quaternion.Euler(0f, 0f, 0f);
			}
			
			
			
		}
		// press J to change left leg 
		
		if (Input.GetKeyDown (KeyCode.D)) {

			leftLegState++;
			if (leftLegState > 1) {
				leftLegState = 0;
			}
			if (leftLegState == 0) {
				//leftLeg.transform.eulerAngles = new Vector3(0f, 0f, -90f); // leg out
				leftLegTargetRotation = Quaternion.Euler(0f, 0f, -90f);
			} else if (leftLegState == 1) {
				//leftLeg.transform.eulerAngles = new Vector3(0f, 0f, 0f); // leg down 
				leftLegTargetRotation = Quaternion.Euler(0f, 0f, 0f);
			} 

			
		}	
		
		// press K to change right leg
		
		if (Input.GetKeyDown (KeyCode.K)) {

			rightLegState++;
			if (rightLegState > 1) {
				rightLegState = 0;
			}
			if (rightLegState == 0) {
				//rightLeg.transform.eulerAngles = new Vector3(0f, 0f, 90f); // leg out
				rightLegTargetRotation = Quaternion.Euler(0f, 0f, 90f);
			} else if (rightLegState == 1) {
				//rightLeg.transform.eulerAngles = new Vector3(0f, 0f, 0f); // leg down 
				rightLegTargetRotation = Quaternion.Euler(0f, 0f, 0f);
			} 

			
			
		}

		// slerp all the limbs to new rotations 
		leftArm.transform.rotation = Quaternion.Slerp (currentLeftArmRotation, leftArmTargetRotation, Time.deltaTime*turnSpeed);
		rightArm.transform.rotation = Quaternion.Slerp (currentRightArmRotation, rightArmTargetRotation, Time.deltaTime*turnSpeed);
		leftLeg.transform.rotation = Quaternion.Slerp (currentLeftLegRotation, leftLegTargetRotation, Time.deltaTime*turnSpeed);
		rightLeg.transform.rotation = Quaternion.Slerp (currentRightLegRotation, rightLegTargetRotation, Time.deltaTime*turnSpeed);

	}
}

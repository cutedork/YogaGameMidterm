using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RandomLimb3d : MonoBehaviour {

	public AudioSource singingBowlSound;
	
	private int currentSeconds;
	public float maxCountDown;
	private float countDown;
	public Text countDownText;


	//------------------------------------------
	public Image timeMeter; 
	//------------------------------------------
	private bool timeUp;
	public bool TimeUp {
		get { return timeUp;} 
		set { timeUp = value;}
	}
	
	protected CheckPose3d _checkPose3d;

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
	

	// pose name UI text box
	public Text poseName;
	
	private string[] adjectives; 
	private string[] nouns;
	
	
	// Use this for initialization
	void Start () {

		_checkPose3d = GetComponent<CheckPose3d>();
		
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
		
		
		// create adjectives array 
		adjectives = new string[10];
		adjectives[0] = "floating";
		adjectives[1] = "salted";
		adjectives[2] = "balancing";
		adjectives[3] = "knotted";
		adjectives[4] = "secret";
		adjectives[5] = "fish";
		adjectives[6] = "freedom";
		adjectives[7] = "half";
		adjectives[8] = "happy";
		adjectives[9] = "frog";
		
		// create nouns array
		nouns = new string[10];
		nouns[0] = "baby";
		nouns[1] = "tree";
		nouns[2] = "pretzel";
		nouns[3] = "stick";
		nouns[4] = "stand";
		nouns[5] = "child";
		nouns[6] = "corpse";
		nouns[7] = "moon";
		nouns[8] = "eagle";
		nouns[9] = "camel";
		
		countDown = maxCountDown;
		timeUp = false;
		
		GenerateRandomPose();
		
		
		
	}
	
	// Update is called once per frame
	void Update () {

		float fillMeter;

		// all current rotations for limbs
		Quaternion currentLeftArmRotation = leftArm.transform.rotation; 
		Quaternion currentRightArmRotation = rightArm.transform.rotation;
		Quaternion currentLeftLegRotation = leftLeg.transform.rotation;
		Quaternion currentRightLegRotation = rightLeg.transform.rotation;

		
		// countdown stuff
		
		// check if pose is completed 
		if (countDown < 0) {
			timeUp = true;
			// play singing bowl clip 
			singingBowlSound.Play ();

			// reset countdown
			countDown = maxCountDown;
			Debug.Log ("COUNT DOWN REACHED ZERO"); // this works
		} else {
			countDown -= Time.deltaTime;
			
		}

		fillMeter = countDown / maxCountDown;
		// meter
		timeMeter.fillAmount = fillMeter; 
		
		countDownText.text = Mathf.FloorToInt (countDown) + " seconds left";
		
		// if countdown is over, change pose
		//if (_checkPose.PoseCorrect)
		
		if (timeUp) { 

			// set timeUp back to false
			//timeUp = false;
			
			// set it back to false
			_checkPose3d.PoseCorrect3d = false;
			
			//GenerateRandomPose();


			
		}


		// slerp all the limbs to new rotations 
		leftArm.transform.rotation = Quaternion.Slerp (currentLeftArmRotation, leftArmTargetRotation, Time.deltaTime*turnSpeed);
		rightArm.transform.rotation = Quaternion.Slerp (currentRightArmRotation, rightArmTargetRotation, Time.deltaTime*turnSpeed);
		leftLeg.transform.rotation = Quaternion.Slerp (currentLeftLegRotation, leftLegTargetRotation, Time.deltaTime*turnSpeed);
		rightLeg.transform.rotation = Quaternion.Slerp (currentRightLegRotation, rightLegTargetRotation, Time.deltaTime*turnSpeed);



	}
	
	public void GenerateRandomPose() {



		/* GENERATE A RANDOM POSE WHEN GAME STARTS ---------------------------------- */
		// generate random yoga pose name 
		int adjNum = Random.Range (0,9);
		int nounNum = Random.Range (0,9);
		poseName.text = adjectives[adjNum] + " " + nouns[nounNum] + " pose";

	
		
		// randomly generate leftArmState from 0 - 2
		leftArmState = Random.Range (0,3);
		// check mode
		
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
		
		rightArmState = Random.Range (0,3);
		
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
		
		leftLegState = Random.Range (0,2);
		

		if (leftLegState == 0) {
			//leftLeg.transform.eulerAngles = new Vector3(0f, 0f, -90f); // leg out
			leftLegTargetRotation = Quaternion.Euler(0f, 0f, -90f);
		} else if (leftLegState == 1) {
			//leftLeg.transform.eulerAngles = new Vector3(0f, 0f, 0f); // leg down 
			leftLegTargetRotation = Quaternion.Euler(0f, 0f, 0f);
		} 

		rightLegState = Random.Range (0,2);
		
		if (rightLegState == 0) {
			//rightLeg.transform.eulerAngles = new Vector3(0f, 0f, 90f); // leg out
			rightLegTargetRotation = Quaternion.Euler(0f, 0f, 90f);
		} else if (rightLegState == 1) {
			//rightLeg.transform.eulerAngles = new Vector3(0f, 0f, 0f); // leg down 
			rightLegTargetRotation = Quaternion.Euler(0f, 0f, 0f);
		} 
		
		/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ------------------------------------*/


	}
}
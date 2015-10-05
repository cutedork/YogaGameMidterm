using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RandomLimb : MonoBehaviour {

	public AudioClip singingBowl; 
	AudioSource audio;

	private int currentSeconds;
	public float maxCountDown;
	private float countDown;
	public Text countDownText;

	private bool timeUp;
	public bool TimeUp {
		get { return timeUp;} 
		set { timeUp = value;}
	}

	protected CheckPose _checkPose;

	public GameObject body; 
	
	//left arm
	public GameObject leftArmDown;
	public GameObject leftArmUp;
	public GameObject leftArmOut;
	
	private int leftArmState;
	/*public int getLeftArmState() {
		return leftArmState;
	}
	public void setLeftArmState(int value) {
		leftArmState = value;
	}*/

	public int LeftArmState {
		get { return leftArmState; }
		//set { leftArmState = value; }
	}
	
	// right arm
	public GameObject rightArmDown;
	public GameObject rightArmUp;
	public GameObject rightArmOut;
	
	private int rightArmState;
	public int RightArmState {
		get {return rightArmState; } 
	}
	
	// left leg
	public GameObject leftLegDown;
	public GameObject leftLegOut;
	
	private int leftLegState;
	public int LeftLegState {
		get {return leftLegState; }
	}
	
	// right leg
	public GameObject rightLegDown;
	public GameObject rightLegOut;
	
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
		audio = GetComponent<AudioSource>();
		_checkPose = GetComponent<CheckPose>();
		
		leftArmDown.SetActive(true); 
		leftArmState = 1;
		
		rightArmDown.SetActive(true);
		rightArmState = 1;
		
		leftLegDown.SetActive (true);
		leftLegState = 1;
		
		rightLegDown.SetActive (true);
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
		nouns[1] = "pose";
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

		// countdown stuff

		// check if pose is completed 
		if (countDown < 0) {
			timeUp = true;
			// play singing bowl clip 
			audio.PlayOneShot (singingBowl);

			// reset countdown
			countDown = maxCountDown;
			Debug.Log ("COUNT DOWN REACHED ZERO"); // this works
		} else {
			countDown -= Time.deltaTime;

		}

		countDownText.text = Mathf.FloorToInt (countDown) + " seconds left";
		
		// if countdown is over, change pose
		//if (_checkPose.PoseCorrect)

		if (timeUp) { 

			// set timeUp back to false
			//timeUp = false;

			// set it back to false
			_checkPose.PoseCorrect = false;

			//GenerateRandomPose ();

		}
	}

	public void GenerateRandomPose() {

		/* GENERATE A RANDOM POSE WHEN GAME STARTS ---------------------------------- */
		// generate random yoga pose name 
		int adjNum = Random.Range (0,9);
		int nounNum = Random.Range (0,9);
		poseName.text = adjectives[adjNum] + " " + nouns[nounNum];
		
		
		
		// randomly generate leftArmState from 0 - 2
		leftArmState = Random.Range (0,3);
		// check mode
		
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
		
		rightArmState = Random.Range (0,3);
		
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
		
		leftLegState = Random.Range (0,2);
		
		if (leftLegState == 0) {
			leftLegDown.SetActive(false);
			leftLegOut.SetActive (true);
			
		} else if (leftLegState == 1) {
			leftLegDown.SetActive(true);
			leftLegOut.SetActive (false);
		}
		
		rightLegState = Random.Range (0,2);
		
		if (rightLegState == 0) {
			rightLegDown.SetActive(false);
			rightLegOut.SetActive (true);
			
		} else if (rightLegState == 1) {
			rightLegDown.SetActive(true);
			rightLegOut.SetActive (false);
		}
		
		/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ------------------------------------*/

	}
}

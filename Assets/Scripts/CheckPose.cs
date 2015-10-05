using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckPose : MonoBehaviour {

	public Text scoreText;
	private int score;

	public Text healthText;
	private int health;

	protected RandomLimb _randomLimb;
	protected ChangeLimbs _changeLimbs;

	public GameObject faceCalm; 
	public GameObject faceMeh;
	public GameObject faceHelp;

	// boolean 
	private bool poseCorrect; 
	public bool PoseCorrect {
		get { return poseCorrect;} 
		set {poseCorrect = value;}
	}

	// Use this for initialization
	void Start () {

		poseCorrect = false;
		_randomLimb = GetComponent<RandomLimb>();
		_changeLimbs = GetComponent<ChangeLimbs>();
		score = 0; // this is p hacky
		health = 3;
	}
	
	// Update is called once per frame
	void Update () {
		//display score 
		scoreText.text = "Poses completed: " + score;
		healthText.text = health + " Health Left."; 

		// emotional state
		if (health == 3) {
			faceCalm.SetActive(true);
			faceMeh.SetActive(false);
			faceHelp.SetActive(false);
		} else if (health == 2) {
			faceCalm.SetActive(false);
			faceMeh.SetActive(true);
			faceHelp.SetActive(false);
		} else if (health < 2) {
			faceCalm.SetActive(false);
			faceMeh.SetActive(false);
			faceHelp.SetActive(true);
		}




		// check pose when time is up 
		if ((_randomLimb.TimeUp) &&
			(_randomLimb.LeftArmState == _changeLimbs.LeftArmState) && 
		    (_randomLimb.RightArmState == _changeLimbs.RightArmState) && 
		    (_randomLimb.LeftLegState == _changeLimbs.LeftLegState) &&
		    (_randomLimb.RightLegState == _changeLimbs.RightLegState)) {
			poseCorrect = true;
			score++;
		} else {
			poseCorrect = false;
		}

		if (_randomLimb.TimeUp && !poseCorrect){
			health--;
			Debug.Log ("YOU LOST HEALTH");
		}

		if (_randomLimb.TimeUp) {
			_randomLimb.GenerateRandomPose();
		}

		_randomLimb.TimeUp = false;

		// check if you  win or lose
		if (score == 10) {
			Application.LoadLevel("WinScene");
		}

		if (health == 0) {
			Application.LoadLevel ("LoseScene");
		}
	
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckPose3d : MonoBehaviour {

	public AudioSource pointSound;
	public AudioSource loseSound;

	public Text scoreText;
	private int score;
	
	public Text healthText;
	private int health;
	
	protected RandomLimb3d _randomLimb3d;
	protected ChangeLimbs3d _changeLimbs3d;

	/*
	public GameObject faceCalm; 
	public GameObject faceMeh;
	public GameObject faceHelp;
	*/

	// boolean 
	private bool poseCorrect3d; 
	public bool PoseCorrect3d {
		get { return poseCorrect3d;} 
		set {poseCorrect3d = value;}
	}
	
	// Use this for initialization
	void Start () {
		
		poseCorrect3d = false;
		_randomLimb3d = GetComponent<RandomLimb3d>();
		_changeLimbs3d = GetComponent<ChangeLimbs3d>();
		score = 0; // this is p hacky
		health = 3;
	}
	
	// Update is called once per frame
	void Update () {
		//display score 
		scoreText.text = "Poses completed: " + score;
		healthText.text = health + " Health Left"; 

		/* 
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
		*/
		
		
		
		// check pose when time is up 
		if ((_randomLimb3d.TimeUp) &&
		    (_randomLimb3d.LeftArmState == _changeLimbs3d.LeftArmState) && 
		    (_randomLimb3d.RightArmState == _changeLimbs3d.RightArmState) && 
		    (_randomLimb3d.LeftLegState == _changeLimbs3d.LeftLegState) &&
		    (_randomLimb3d.RightLegState == _changeLimbs3d.RightLegState)) {
			poseCorrect3d = true;
			score++;
		} else {
			poseCorrect3d = false;
		}
		
		if (_randomLimb3d.TimeUp && !poseCorrect3d){
			health--;
			loseSound.Play ();
			//Debug.Log ("YOU LOST HEALTH");
		}
		
		if (_randomLimb3d.TimeUp) {
			_randomLimb3d.GenerateRandomPose();
		}
		
		_randomLimb3d.TimeUp = false;
		
		// check if you  win or lose
		if (score == 10) {
			Application.LoadLevel("WinScene");
		}
		
		if (health == 0) {
			Application.LoadLevel ("LoseScene");
		}
		
	}
}

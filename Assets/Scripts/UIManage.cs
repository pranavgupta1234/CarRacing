using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManage : MonoBehaviour {

	public Button[] buttons;
	public Text scoreText;
	public static bool gameOver;
	int score;
	public AudioManager audiomanager;

	// Use this for initialization
	void Start () {
		gameOver = false;
		score = 0;
		InvokeRepeating ("updateScore", 1.0f, 0.5f);
		if (buttons != null) {
			foreach (Button button in buttons) {
				if (button) {
					button.gameObject.SetActive (false);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreText) {
			scoreText.text = "Score : " + score;
			Debug.Log (gameOver);
		}
	}

	public void Play(){
		Application.LoadLevel ("level1");
	}

	public void updateScore(){
		if (gameOver == false) {
			score++;
		}
	}

	public void gameFinish(){
		Debug.Log ("game over");
		gameOver = true;
		foreach (Button button in buttons) {
			button.gameObject.SetActive (true);
		}
	}


	public void Pause(){
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
		if (audiomanager.carSound.isPlaying) {
			audiomanager.carSound.Stop ();
		} else {
			audiomanager.carSound.Play ();
		}
	
	}

	public void Replay(){
		Application.LoadLevel (Application.loadedLevel);
	}

	public void exit(){
		Application.Quit ();
	}

	public void menu(){
		SceneManager.LoadScene ("menu");
	}
}

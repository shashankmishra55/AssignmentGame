using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	// Use this for initialization

	private UnityAction gameOverListener;
	public Text scoreLbl;
	private bool gameOver;
	private GameOverMenu gameOverMenu;
	public GameObject gameOverUI;
	void Awake(){
		gameOverListener = new UnityAction (onGameOver);
	}

	void OnEnable(){
		EventManager.StartListening ("gameOver", gameOverListener);
	}

	void OnDisable(){
		EventManager.StopListening ("gameOver", gameOverListener);
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!gameOver)
		scoreLbl.text =   Time.timeSinceLevelLoad.ToString("0");
	}

	void onGameOver(){
		GetComponent<AudioSource> ().Stop ();
		gameOver = true;
		gameOverUI.SetActive (true);

		gameOverMenu = gameOverUI.GetComponent ("GameOverMenu") as GameOverMenu;
		gameOverMenu.ShowScore ( int.Parse(scoreLbl.text));
		scoreLbl.gameObject.transform.parent.gameObject.SetActive (false);
	}
}

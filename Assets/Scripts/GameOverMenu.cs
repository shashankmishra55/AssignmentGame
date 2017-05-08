using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverMenu : MonoBehaviour {

	// Use this for initialization
	public Text scoreLbl;
	public Text bestScoreLbl;
	private int bestScore;
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowScore(int score){
		scoreLbl.text = score.ToString();
		if (PlayerPrefs.HasKey ("bestScore")) {
			bestScore = PlayerPrefs.GetInt ("bestScore");
		} else {
			bestScore = 0;
			PlayerPrefs.SetInt ("bestScore", bestScore);
		}
		if (score >= bestScore) {
			bestScore = score;
			PlayerPrefs.SetInt ("bestScore", bestScore);
		}
			
		bestScoreLbl.text = PlayerPrefs.GetInt ("bestScore").ToString();
		PlayerPrefs.Save ();
	
	}

	public void TryAgain(){
		SceneManager.LoadScene (1);
	}
}

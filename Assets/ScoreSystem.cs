using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {
	public Text ScoreBoard;
	public Text Highscore;
	private int score;
	private int oldHighscore;

	public void UpdateScore(int val){
		score += val;
	}
	void Awake(){
		oldHighscore = PlayerPrefs.GetInt("highscore", 0); 
		if (oldHighscore == null) {
			PlayerPrefs.SetInt("highscore", 0);
			oldHighscore=0;
		}
		Highscore.text = "High Score: " + oldHighscore;
	}

}

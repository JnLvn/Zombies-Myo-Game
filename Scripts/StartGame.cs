using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	private int highScore;
	string highScoreKey = "HighScore";
	public GUIText highScoreText;

	void Start()
	{
		// checks for highscore in player prefs. If no highscore set to zero.
		highScore = PlayerPrefs.GetInt(highScoreKey,0);
		highScoreText.text = "High Score: " + highScore;
	}

	public void Game()
	{
		Application.LoadLevel("Main");
	}

}

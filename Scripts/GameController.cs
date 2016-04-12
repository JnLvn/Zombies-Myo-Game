using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject zombie;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	private bool gameOver;

	public GUIText scoreText;
	public GUIText healthText;
	private int health = 100;
	private static int score;
	private int highScore;
	private string highScoreKey = "HighScore";

	//public Mover mover;

	// Use this for initialization
	void Start () {
	
		Mover.speed = 0.1f;

		score = 0;
		highScore = 0;
		UpdateScore ();
		UpdateHealth ();
		StartCoroutine (SpawnWaves ());
		//Get the highScore from player prefs if it's there, zero otherwise. 
		highScore = PlayerPrefs.GetInt(highScoreKey,0);
	}

	// spawn waves of zombies
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.Euler(0,180,0);
				Instantiate (zombie, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
				
			}
			yield return new WaitForSeconds (waveWait);
			
			Mover.speed +=0.02f;  // increase hazard-objects speed by 2 after each wave
			
			if(gameOver)
			{
				break; // if game over, stop waves of zombie-objects.
			}
			
			//score++; // increase score by 1 after each wave.
			//UpdateScore();
		}
	}

	public void GameOver ()
	{
		gameOver = true;
		Application.LoadLevel ("GameOver");
	}

	public void Restart()
	{
		Application.LoadLevel("Main");
	}

	public void MainMenu()
	{
		Application.LoadLevel("Menu");
	}

	// adds scores from destroying zombie-objects.
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public void takeHealth (int newHealth)
	{
		health -= newHealth;
		UpdateHealth ();
	}
	
	void UpdateHealth ()
	{
		if (health <= 0) {
			GameOver();
		}
		healthText.text = "Health: " + health;
	}

	void OnDisable()
	{
		//If our scoree is greter than highscore, set new higscore and save.
		if(score>highScore){
			PlayerPrefs.SetInt(highScoreKey, score);
			PlayerPrefs.Save();
		}
	}
}

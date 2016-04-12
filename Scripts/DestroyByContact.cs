using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	private GameController gameController;

	public int scoreValue;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			//Debug.Log("Found game controller");
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")  // If the objects tag is Boundary, do nothing
		{
			gameController.takeHealth(25);
			Destroy(gameObject);

			return;
		}
		
		if (other.tag == "PowerUp")  // If the objects tag is powerUp, do nothing
		{
			return;
		}

		if (other.tag == "Player") // If objects tag is player, destroy and end game
		{
			Debug.Log("Player Dead");
			gameController.GameOver ();
		}
		
		Destroy(other.gameObject);
		Destroy(gameObject);


		gameController.AddScore (scoreValue); // if zombie-object destroyed add to score.
	}
}

using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {

	public float speed;



	void Update() {
	
		transform.Rotate(Vector3.forward,speed*Time.deltaTime,0);
	}
}

using UnityEngine;
using System.Collections;

public class ShotMover : MonoBehaviour {

	public static float speed = 1f;

	public Rigidbody rb;
	
	void Start() {
		rb = GetComponent<Rigidbody>();
	}
	void FixedUpdate() {
		rb.MovePosition(transform.position + transform.forward * speed);
	}

}

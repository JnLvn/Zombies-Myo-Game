using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	
	public static float speed = 0.1f;

	public Vector3 teleportPoint;
	public Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}
	void FixedUpdate() {
		rb.MovePosition(transform.position + transform.forward * speed);
	}
	

}

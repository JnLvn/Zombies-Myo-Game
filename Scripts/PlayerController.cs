using UnityEngine;
using System.Collections;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class PlayerController : MonoBehaviour {

	public ThalmicMyo myo;

	public float speed;
	private float nextFire;
	public float fireRate;

	public GameObject shot;
	public Transform shotSpawn;

	private int xtimesHit = 0;
	private int ytimesHit = 0;
	private int ztimesHit = 0;

	private float MinClamp = -50;
	private float MaxClamp = 50;

	private Transform t;
	private Vector3 ClampY;

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate ()
	{
		if( Input.GetKeyDown( KeyCode.RightArrow )){
			ytimesHit++;
		}
		if( Input.GetKeyDown( KeyCode.LeftArrow )){
			ytimesHit--;
		}

		
		this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(xtimesHit*90,Mathf.Clamp(ytimesHit*10, MinClamp, MaxClamp),ztimesHit*90), Time.deltaTime*speed);

	}

	// Update is called once per frame
	void Update ()
	{
		// Takes input from fire button
		if (Input.GetButton("Fire1") || (myo.pose == Thalmic.Myo.Pose.Fist) || (myo.pose == Thalmic.Myo.Pose.WaveIn) || (myo.pose == Thalmic.Myo.Pose.WaveOut) && Time.time > nextFire) 
		{

				nextFire = Time.time + fireRate; // calculates the time until next fire
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation); // create shot from player ship position1
		}


	}
}

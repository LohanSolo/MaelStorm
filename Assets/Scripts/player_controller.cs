using UnityEngine;
using System.Collections;

public class player_controller : MonoBehaviour {
	private Vector3 player_velocity=new Vector3(0,0,0);
	public float speed, angular_velocity, fireRate;
	public GameObject engine, shot, shotSpawn;
	private float nextFire;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			//Quaternion q=Quaternion.Euler(gameObject.transform.rotation.x+90,gameObject.transform.rotation.y,gameObject.transform.rotation.z);;
			//Quaternion q=Quaternion.Euler(shotSpawn.transform.rotation.x+90,shotSpawn.transform.rotation.y, shotSpawn.transform.rotation.z);
			Instantiate(shot,shotSpawn.transform.position,shotSpawn.transform.rotation);

			//bolts.transform.;
			//AudioSource audio=GetComponent<AudioSource>();
			//audio.Play();
		}
	}
	void FixedUpdate(){
		float moververtical = Input.GetAxis ("Vertical");
		float movehorizontal = Input.GetAxis ("Horizontal");
		player_velocity = player_velocity + Vector3.forward * moververtical*speed;
		Vector3 vector=transform.forward*moververtical;
		Rigidbody rigidbody = GetComponent<Rigidbody> ();
		rigidbody.velocity = rigidbody.velocity+vector*speed; 
		transform.Rotate (0,angular_velocity*movehorizontal,0);

		//rigidbody.position = new Vector3 (
		//	Mathf.Clamp(rigidbody.position.x,boundary.xMin,boundary.xMax),
		//	0.0f,
		//	Mathf.Clamp(rigidbody.position.z,boundary.zMin,boundary.zMax)
		//	);

	}

}

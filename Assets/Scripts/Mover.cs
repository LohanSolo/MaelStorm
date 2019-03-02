using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float speed;
	//public Transform player;
	// Use this for initialization
	void Start () {
		Rigidbody rigidbody = gameObject.GetComponent<Rigidbody> ();
		rigidbody.velocity = transform.forward * speed;

		//rigidbody.rotation = transform.forward;
		//GameObject player = GameObject.FindGameObjectWithTag ("Player");
		//rigidbody.rotation=Quaternion.Euler(rigidbody.rotation.x+90, player.transform.rotation.y,player.transform.rotation.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

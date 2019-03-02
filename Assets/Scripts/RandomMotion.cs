using UnityEngine;
using System.Collections;

public class RandomMotion : MonoBehaviour {

	// Use this for initialization
	public float tumble, velocity;
	//public float minX, maxX, minZ, maxZ;
	void Start () {
		//gameObject.transform.rotation = Quaternion.Euler(Random.Range(0,1)*tumble,Random.Range(0,1)*tumble,Random.Range(0,1)*tumble);
		Rigidbody rigidbody = gameObject.GetComponent<Rigidbody> ();
		rigidbody.velocity = new Vector3(Random.Range(0,5)*velocity/(50*gameObject.transform.localScale.x),0,Random.Range(0,5)*velocity/(50*gameObject.transform.localScale.z) );
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;

		//gameObject.transform.rotati = Random.insideUnitSphere * 5;
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody rigidbody = gameObject.GetComponent<Rigidbody> ();
		rigidbody.position = new Vector3 (rigidbody.position.x,1.0f,rigidbody.position.z);
	}
}

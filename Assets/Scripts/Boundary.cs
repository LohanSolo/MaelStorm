using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerExit(Collider other){
		Vector3 old_pos=other.gameObject.transform.position;
		Vector3 new_pos = new Vector3 ();
		new_pos.x = -old_pos.x ;//20
		new_pos.z = -old_pos.z ;//10
		new_pos.y = old_pos.y;
		other.gameObject.transform.position = new_pos;
	}
}

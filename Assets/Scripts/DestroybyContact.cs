using UnityEngine;
using System.Collections;

public class DestroybyContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject Asteroid;
	public int hazard_points;
	public Canvas game_over;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary" || other.tag=="Player") {
			return;
		}else
		{
			Instantiate(explosion, gameObject.transform.position,gameObject.transform.rotation);
			if(other.tag=="Asteroid"){
				if(other.transform.lossyScale.x>0.6){
					Debug.Log(other.transform.localScale.x.ToString());
					GameObject go1=(GameObject) Instantiate(Asteroid,gameObject.transform.position, gameObject.transform.rotation);
					go1.transform.localScale=go1.transform.localScale/2;
					GameObject go2=(GameObject) Instantiate(Asteroid,gameObject.transform.position, gameObject.transform.rotation);
					go2.transform.localScale=go2.transform.localScale/2;

				}
				GameObject gamecontrollerobject=GameObject.FindWithTag("GameController");
				GameController gameController=gamecontrollerobject.GetComponent<GameController>();
				gameController.updateScore((int)(hazard_points*other.transform.lossyScale.x));
			}
			if(gameObject.tag=="Player"){
				game_over.enabled=true;
			}
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public Transform explosion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider coll){
		Instantiate (explosion, transform.position, transform.rotation);
		if (coll.gameObject.tag == "Com") {
			Destroy (gameObject);
		}
	}
}

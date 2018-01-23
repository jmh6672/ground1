using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Destroy : MonoBehaviour {
	float desTime = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		desTime -= Time.time;
		if (this.GetComponent<ParticleSystem> ().isPlaying == false || desTime <= 0f)
			Destroy (this.gameObject);
	}
}
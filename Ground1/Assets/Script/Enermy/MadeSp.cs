using UnityEngine;
using System.Collections;

public class MadeSp : MonoBehaviour {
	public GameObject spider;
	public Transform spPoint;

	GameObject target;
	UnityEngine.AI.NavMeshAgent nav;

	int a;
	float dist;
	public float madTime;

	void Start () {
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		a = Random.Range (0,4);
	}
	void Update () {
		madTime -= Time.deltaTime;
		target = GameObject.FindWithTag ("Com" + a);
		if (target == null) {
			a = Random.Range (0, 4);
		} else {
			nav.SetDestination (target.transform.position);
			dist = Vector3.Distance (target.transform.position, transform.position);
		}

		if (dist < 10f) {
			a = Random.Range (0,4);
		}

		if (madTime <= 0f && Manager.manager != null) {
			if (Manager.manager.IsMade == true) {
				Instantiate (spider, spPoint.position, spPoint.rotation);
				Manager.manager.countEnermy += 1;
				madTime = 3f;
			}
		}
	}
}
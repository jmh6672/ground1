using UnityEngine;
using System.Collections;

public class MadeGun : MonoBehaviour {
	public GameObject gun;
	public GameObject tank;
	public Transform spPoint;

	GameObject target;
	UnityEngine.AI.NavMeshAgent nav;

	int a;
	public float madGunTime = 3.0f;
	public float madTankTime = 11.0f;
	float madeGun;
	float madeTank;
	float dist;

	void Start () {
		madeGun=madGunTime;
		madeTank=madTankTime;
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		a = Random.Range (0,4);
	}
	void Update () {
		madeGun -= Time.deltaTime;
		madeTank -= Time.deltaTime;
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
		if (Manager.manager != null) {
			if (madeGun <= 0f && Manager.manager.IsMade == true) {
				Instantiate (gun, spPoint.position, spPoint.rotation);
				Manager.manager.countEnermy += 1;
				madeGun = madGunTime;
			}
			if (madeTank <= 0f && Manager.manager.IsMade == true) {
				Instantiate (tank, spPoint.position, spPoint.rotation);
				Manager.manager.countEnermy += 1;
				madeTank = madTankTime;
			}
		}
	}
}
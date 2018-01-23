using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {
	public Transform bullet;
	public Transform spPoint;

	GameObject target;
	Animation animation;
	UnityEngine.AI.NavMeshAgent nav;
	Transform obj;

	int a;
	float dist;
	float delayTime = 0f;

	void Start () {
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		animation = GetComponent<Animation> ();
		a = Random.Range (0,3);
	}
	void Update () {
		delayTime -= Time.deltaTime;
		target = GameObject.FindWithTag ("Com" + a);
		if (target == null) {
			a = Random.Range (0, 4);
		} else {
			dist = Vector3.Distance (target.transform.position, transform.position);
			nav.SetDestination (target.transform.position);
		}

		if (dist < 10f && target != null) {
			transform.LookAt(new Vector3(target.transform.position.x,0f,target.transform.position.z));
			nav.SetDestination (transform.position);
			FireBullet ();
		} 
	}

	void FireBullet() 
	{
		if (delayTime <= 0) {
			delayTime = 2.5f;
			animation.Play ("attack");
			//			AudioSource.PlayClipAtPoint(FireSound, spPoint.position);
			obj = Instantiate(bullet, spPoint.position, spPoint.rotation) as Transform;
			obj.GetComponent<Rigidbody>().AddForce(spPoint.forward * 3000);
		}
	}

}
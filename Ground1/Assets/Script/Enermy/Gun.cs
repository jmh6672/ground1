using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	public Transform bullet;
	public Transform spPoint;

	GameObject target;
	Animation animation;
	UnityEngine.AI.NavMeshAgent nav;

	int a;
	float dist;
	float delayTime = 0f;

	void Start () {
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		animation = GetComponent<Animation> ();
		a = Random.Range (0,4);
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

		bool hit = this.gameObject.GetComponent<Life> ().IsHit;

		if (dist < 7f && target != null)
			transform.LookAt(new Vector3(target.transform.position.x,0f,target.transform.position.z));
		if (dist < 5f & hit == false) {
			nav.SetDestination (transform.position);
			if (delayTime <= 0) {
				FireBullet ();
				delayTime = 1.5f;
			}
		} else if(hit == true){
			animation.CrossFade ("move");
			a = Random.Range (0, 4);
			nav.speed = 15;
			nav.acceleration = 40;
			nav.angularSpeed = 400;
		}
	}

	void FireBullet() 
	{
			animation.Play ("attack");
//			AudioSource.PlayClipAtPoint(FireSound, spPoint.position);
			Transform obj = Instantiate(bullet, spPoint.position, spPoint.rotation) as Transform;
			obj.GetComponent<Rigidbody>().AddForce(spPoint.forward * 1000);
	}
}
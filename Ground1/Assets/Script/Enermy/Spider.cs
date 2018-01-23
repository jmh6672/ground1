using UnityEngine;
using System.Collections;

public class Spider : MonoBehaviour {
	public static Spider manager;

	GameObject player;
	Animator animator;
	UnityEngine.AI.NavMeshAgent nav;

	public float dist;

	void Start () {
		manager = this;
		player = GameObject.FindGameObjectWithTag ("Player");
		animator = GetComponent<Animator> ();
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}
	void Update () {
		dist = Vector3.Distance (transform.position, player.transform.position);

		if (dist < 0.9f) {
			transform.LookAt (player.transform.position);
			nav.SetDestination(transform.position);
			animator.SetTrigger ("attack");
		} else {
			animator.SetBool ("move", true);
			nav.SetDestination(player.transform.position);
		}
	}
}
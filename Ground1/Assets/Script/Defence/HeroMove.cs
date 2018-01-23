using UnityEngine;
using System.Collections;

public class HeroMove : MonoBehaviour {
	public Transform hero;

	bool IsMove = true;

	float rotationSpeed = 15;

	Animator animator;
	Vector3 inputVec;
	Vector3 targetDirection;

	void Start () {
		animator = hero.gameObject.GetComponent<Animator> ();
	}

	void Update()
	{
		float z = Input.GetAxisRaw("Horizontal");
		float x = -(Input.GetAxisRaw("Vertical"));
		inputVec = new Vector3(z, 0, -x);

		if (IsMove == true)
			transform.position = transform.position + inputVec.normalized * Time.deltaTime * 8f;

		if (x != 0 || z != 0) {
			animator.SetBool ("Run", true);
		}
		else
			animator.SetBool("Run", false);

		if (Input.GetKeyDown (KeyCode.Space)) 
			StartCoroutine ("Land");
		if (Input.GetKeyDown (KeyCode.E)) 
			StartCoroutine ("Roll");

		UpdateMovement();
	}

	IEnumerator Land()
	{
		animator.SetTrigger ("Jump");
		yield return new WaitForSeconds(.3f);
		animator.SetTrigger ("Land");
	}
	IEnumerator Roll(){
		animator.SetTrigger ("RollForward");
		HeroDamaged.manager.IsRoll = true;
		yield return new WaitForSeconds(.5f);
		HeroDamaged.manager.IsRoll = false;
	}

	void OnTriggerEnter(Collider other){
//		if (other.transform.tag == "Plane")
//			IsMove = true;
//		else
//			IsMove = false;
	}

	void GetCameraRelativeMovement()
	{  
		Transform cameraTransform = Camera.main.transform;
		   
		Vector3 forward = cameraTransform.TransformDirection(Vector3.forward);
		forward.y = 0;
		forward = forward.normalized;

		Vector3 right= new Vector3(forward.z, 0, -forward.x);

		float v= Input.GetAxisRaw("Vertical");
		float h= Input.GetAxisRaw("Horizontal");

		targetDirection = h * right + v * forward;
	}

	void RotateTowardMovementDirection()  
	{
		if (inputVec != Vector3.zero)
		{
			hero.rotation = Quaternion.Slerp(hero.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * rotationSpeed);
		}
	}

	void UpdateMovement()
	{
		Vector3 motion = inputVec;

		motion *= (Mathf.Abs(inputVec.x) == 1 && Mathf.Abs(inputVec.z) == 1)? .9f*Time.deltaTime:1*Time.deltaTime;

		RotateTowardMovementDirection();  
		GetCameraRelativeMovement();  
	}

}
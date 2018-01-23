using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeroDamaged : MonoBehaviour {
	public static HeroDamaged manager;
	public GameObject weaphon;
	public GameObject gage;
	public Slider hitTimeSlider;
	public Text hitCountText;

	Animator heroAnim;

	public bool IsStunn;
	public bool IsRoll;
	public int hitCount;
	float hitTime = 0f;
	bool IsHit = false;
	// Use this for initialization
	void Awake () {
		manager = this;
		heroAnim = GetComponent<Animator> ();
		IsRoll = false;
		IsStunn = false;
		hitCount = 3;
	}

	// Update is called once per frame
	void Update () {
		Vector3 screenPos = Camera.main.WorldToScreenPoint (transform.position);
		gage.transform.position = new Vector3 (screenPos.x+30f, screenPos.y+40f, 0f);

		hitTime -= Time.deltaTime;
		hitTimeSlider.value = hitTime;
		hitCountText.text = hitCount.ToString();
		if (IsHit) 
			hitTime = 3f;
		if (hitTime <= 0f)
			hitCount = 3;
		if (hitCount <= 0) {
			StartCoroutine ("stunn");
			IsStunn = true;
		}
	}

	void OnTriggerEnter (Collider coll)	{
		if (coll.tag == "Spider" && IsHit == false && IsRoll == false) {
			if (hitCount > 0) {
				StartCoroutine ("hit");
				IsStunn = false;
			}
		}
	}

	IEnumerator hit(){
		IsHit = true;
		heroAnim.SetTrigger ("Hit");
		hitCount -= 1;
		yield return new WaitForSeconds (0.12f);
		IsHit = false;
	}
	IEnumerator stunn(){
		heroAnim.enabled = false;
		transform.parent.GetComponent<HeroMove> ().enabled = false;
		yield return new WaitForSeconds (2f);
		heroAnim.enabled = true; 
		transform.parent.GetComponent<HeroMove> ().enabled = true;
		hitCount = 3;
	}
}

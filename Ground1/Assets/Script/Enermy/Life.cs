using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Life : MonoBehaviour {
	GameObject Weaphon;
	GameObject uiRoot;
//	public GameObject desParticle;
	public GameObject gage;
	public float gageYpos;
	public float life;
	public float score;
	public bool IsHit;

	void Awake(){
		gage.GetComponent<RectTransform> ().rotation = Quaternion.identity;
	}
	void Start () {
		uiRoot = GameObject.Find ("Canvas/Enermy");
		gage.GetComponent<Slider> ().maxValue = life;
		gage.GetComponent<Slider> ().value = life;
		gage.transform.SetParent(uiRoot.transform);
		Weaphon = GameObject.FindWithTag("Weaphon");
	}
	void Update () {
		gage.GetComponent<RectTransform> ().localScale = new Vector3(1,1,1);
		Vector3 screenPos = Camera.main.WorldToScreenPoint (transform.position);
		if (life <= 0f) {
			Destroy (gameObject);
			Destroy (gage);
			Manager.manager.countEnermy -= 1;
			Manager.manager.killScore += score;
			//			Instantiate (desParticle,transform.position,transform.rotation);
		} else {
			gage.transform.position = new Vector3(screenPos.x, screenPos.y+gageYpos, 0f);
		}

		RaycastHit hit;
		if (Physics.Raycast (Weaphon.transform.position,Weaphon.transform.forward ,out hit, Mathf.Infinity,9)){
			if (EnergyGage.manager.IsBeam == true) {
				if (Vector3.Distance (hit.point, transform.position) <= 1f) {
					life -= 0.2f;
					//gage.GetComponent<Slider> ().value -= 0.2f;
					IsHit = true;
					//Debug.Log (life);
				}
				if (EnergyGage.manager.SuperBeam == true && Vector3.Distance (hit.point, transform.position) <= 2f) {
					life -= 0.4f;
					//gage.GetComponent<Slider> ().value -= 0.4f;
					IsHit = true;
					//Debug.Log (life);
				}
			}
			if (Input.GetButtonDown("Fire1") && Vector3.Distance (hit.point, transform.position) <= 1f) {
				life -= 1;
				IsHit = true;
			}
		}

		if (OptionUI.manager.IsGageOn == false)
			gage.SetActive (false);
		else {
			gage.SetActive (true);
			gage.GetComponent<Slider> ().value = life;
		}
		StartCoroutine ("hitDelay");
	}

	IEnumerator hitDelay(){
		yield return new WaitForSeconds (0.2f);
		IsHit = false;
	}
}

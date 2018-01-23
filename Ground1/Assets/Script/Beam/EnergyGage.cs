using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnergyGage : MonoBehaviour {
	public static EnergyGage manager;
	public GameObject alpha;

	public Slider gage;
	public bool IsBeam=false;
	public bool SuperBeam=false;

	void Start () {
		manager = this;
	}
		
	void Update () {
		Vector3 screenPos = Camera.main.WorldToScreenPoint (transform.position);
		gage.transform.position = new Vector3(screenPos.x, screenPos.y, gage.transform.position.z);

		if (gage.value < 1f && IsBeam == false) {
			gage.value += Time.deltaTime * 0.2f;
			gage.GetComponent<Animator> ().enabled =false;
			Color tmp = alpha.GetComponent<Image> ().color;
			tmp.a = 255f;
			alpha.GetComponent<Image>().color = tmp;
		}else if (gage.value > 0.999f) {
			SuperBeam = true;
			gage.GetComponent<Animator> ().enabled = true;
		}
	}
}

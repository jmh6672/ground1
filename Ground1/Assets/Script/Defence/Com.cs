using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Com : MonoBehaviour {
	public float life = 100f;
	public Transform explosion;
	public GameObject damaged;
	public GameObject gage;
	public GameObject hpColor;

	GameObject uiRoot;
	// Use this for initialization
	void Start () {
		gage.GetComponent<RectTransform> ().rotation = Quaternion.identity;
		uiRoot = GameObject.Find ("Canvas/Com");
		gage.GetComponent<Slider> ().maxValue = life;
		gage.GetComponent<Slider> ().value = life;
		gage.transform.SetParent(uiRoot.transform);
	}
	// Update is called once per frame
	void Update () {
		gage.GetComponent<RectTransform> ().localScale = new Vector3(1,1,1);
		Vector3 screenPos = Camera.main.WorldToScreenPoint (transform.position);

		if (life <= 30f) {
			damaged.SetActive (true);
		}
		if (life <= 0f) {
			Destroy (gameObject);
			Destroy (gage);
			MadeComputer.manager.count -= 1;
			//			Instantiate (desParticle,transform.position,transform.rotation);
		} else {
			gage.transform.position = new Vector3 (screenPos.x, screenPos.y, 0f);
			gage.GetComponent<Slider> ().value = life;
			Color tmp = hpColor.GetComponent<Image> ().color;
			tmp.r = 255.0f - (life * 4f);
			tmp.g = 0.0f + (life * 4f);
			hpColor.GetComponent<Image> ().color = tmp;
		}
	}
	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Bullet")
			life -= 1f;
		if (coll.gameObject.tag == "Bullet1")
			life -= 3f;
	}
}
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour {
	public static OptionUI manager;
	// Use this for initialization
	public Toggle sound;
	public Toggle gage;
	public bool IsGageOn;
	public bool IsSoundOn;

	void Start () {
		manager = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Gage(){
		if (IsGageOn == true) {
			gage.isOn = false;
			IsGageOn = false;
		} else {
			gage.isOn = true;
			IsGageOn = true;
		}
	}
	public void Sound(){
		if (AudioListener.pause == true) {
			AudioListener.pause = false;
			sound.isOn = true;
		} else {
			AudioListener.pause = true;
			sound.isOn = false;
		}
	}
}

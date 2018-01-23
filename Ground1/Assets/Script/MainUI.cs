using UnityEngine;
using System.Collections;

public class MainUI : MonoBehaviour {
	public GameObject OptionUI;

	public bool isOption;

	// Update is called once per frame
	void Update () {
		if(isOption==true)
			OptionUI.SetActive (true);
		else
			OptionUI.SetActive (false);
	}
	public void StartUI(){
		Application.LoadLevel (1);
	}
	public void HowTo(){
		Application.LoadLevel (2);
	}
	public void Option(){
		if (isOption == true)
			isOption = false;
		else
			isOption = true;
	}
}

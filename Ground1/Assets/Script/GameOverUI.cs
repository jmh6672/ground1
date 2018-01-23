using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour {
	public Text time;
	public Text kill;
	public Text total;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time.text = Manager.manager.timeScore.ToString("0000");
		kill.text = Manager.manager.killScore.ToString("0000");
		total.text = (Manager.manager.timeScore + Manager.manager.killScore).ToString("0000");
	}
	public void ReStart(){
		Application.LoadLevel (1);
	}
	public void Menu(){
		Application.LoadLevel (0);
	}
}
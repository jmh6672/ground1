using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
	public static Manager manager;

	public GameObject Hero;
	public GameObject Weaphon;
	public GameObject GameOverUI;
	public GameObject scoreText;
	public GameObject optionUI;
// 	public GameObject madeGun;
//	public GameObject madeSp;
	public Text countEneryText;
	public Text countComText;
	public Text timeText;
	public Text killText;

	public int countEnermy = 2;
	public bool IsMade;
	public bool IsEnd;
	public float killScore;
	public float timeScore;

	bool isPuase;

	void Start(){
		manager = this;
		IsMade = true;
		IsEnd = false;
		isPuase = false;
		killScore = 0f;
		timeScore = 0f;
	}
	// Update is called once per frame
	void Update () {
		countEneryText.text = countEnermy.ToString();
		countComText.text = MadeComputer.manager.count.ToString();

		if(IsEnd==false)
			timeScore += Time.deltaTime;

		if (countEnermy > 59) 
			IsMade = false;
	
		if (MadeComputer.manager.count == 10)
			GameOver ();

		if (Input.GetKey (KeyCode.Tab)) {
			scoreText.SetActive(true);
			scoreText.GetComponent<Text>().text = "Score : " + killScore.ToString ("000000");
			timeText.text = "TIME : "+timeScore.ToString("00 : 00");
			killText.text = "KILL : "+killScore.ToString();
		} else {
			scoreText.SetActive(false);
		}

		if (Input.GetKey (KeyCode.Escape)) {
			if (isPuase == false) {
				optionUI.SetActive (true);
				isPuase = true;
				Time.timeScale = 0;
			} else {
				optionUI.SetActive (false);
				isPuase = false;
				Time.timeScale = 1f;
			}
		}
	}
	public void ReGame(){
		if (isPuase == true) {
			optionUI.SetActive (false);
			isPuase = false;
			Time.timeScale = 1f;
		}
	}
	public void MainBtn(){
		Time.timeScale = 1f;
		Application.LoadLevel (0);
	}

	void GameOver(){
		GameOverUI.SetActive (true);	
		Hero.GetComponent<HeroMove> ().enabled = false;
		Weaphon.GetComponent<MultiShooter> ().enabled = false;
		IsMade = false;
		IsEnd = true;
	}
}

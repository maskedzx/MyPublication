using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//ボタンが押されたときの処理
public class PressButton : MonoBehaviour {
	public GameObject modeMenu;
	public GameObject titleMenu;
	public GameObject resultObj;
	public GameObject timeResult;
	private TimeResult timeRs;
	public GameObject PlayCanvas;
	public GameObject HowToObj;
	public GameObject HighScoreObj;
	public GameObject scoreResult;
	private ScoreResult scoreRs;
	public GameObject HiScoreObj;
	private HighScore hiScore;



	void Awake(){
		if (Application.loadedLevelName == "TimeAttack") {
			timeRs = timeResult.GetComponent<TimeResult> ();
		}else if (Application.loadedLevelName == "ScoreAttack") {
			scoreRs = scoreResult.GetComponent<ScoreResult> ();
		}else if (Application.loadedLevelName == "Title") {
			hiScore = HiScoreObj.GetComponent<HighScore> ();
		}

	}

	// タイトル画面で,画面をタップする
	public void ClickTitle(){
		modeMenu.SetActive(true);
		titleMenu.SetActive (false);
	}

	public void ClickScoreAttack(){
		Time.timeScale = 1;
		Application.LoadLevel(1);
		Debug.Log (Time.timeScale);
	}

	public void ClickTimeAttack(){
		Time.timeScale = 1;
		Application.LoadLevel(2);
		Debug.Log (Time.timeScale);
	}

	public void ClickResult(){
		if (Application.loadedLevelName == "TimeAttack") {
			timeRs.end ();
		}else if (Application.loadedLevelName == "ScoreAttack") {
			scoreRs.end ();
		}
		PlayCanvas.SetActive (false);
		resultObj.SetActive (true);
	}

	public void ClickTitleBack(){
		Time.timeScale = 1;
		Application.LoadLevel (0);
		Debug.Log (Time.timeScale);
	}

	public void ClickHowToButton(){
		HowToObj.SetActive(true);
		titleMenu.SetActive (false);
	}

	public void ClickHighScoreButton(){
		HighScoreObj.SetActive(true);
		titleMenu.SetActive (false);
	}

	public void CloseHowTo(){
		HowToObj.SetActive(false);
		titleMenu.SetActive (true);
	}

	public void CloseHighScore(){
		HighScoreObj.SetActive(false);
		titleMenu.SetActive (true);
	}

	public void ResetButton(){
		hiScore.reset ();
	}

}
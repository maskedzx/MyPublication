using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	private float highScore;
	private Text scoreText;
	[SerializeField]
	private GameObject scoreTextObj;
	private float highTime;
	private Text timeText;
	[SerializeField]
	private GameObject timeTextObj;

	void Awake(){
		highScore = PlayerPrefs.GetFloat ("highScore");
		highTime = PlayerPrefs.GetFloat ("highTime");
		scoreText = scoreTextObj.GetComponent<Text> ();
		timeText = timeTextObj.GetComponent<Text> ();
	}

    //ハイスコアの表示

	void Start () {
		if ((highScore == 0) || (highScore == null)){
			scoreText.text = "-";
		}else{		
			scoreText.text = "" + highScore.ToString("F0");
		}
		if ((highTime == 0) || (highTime == 9999)){
			timeText.text = "-";
		}else{		
			timeText.text = "" + highTime.ToString("F2");
		}
	}

    //ハイスコアのリセット

	public void reset(){
		highScore = 0;
		PlayerPrefs.SetFloat ("highScore", highScore);
		highTime = 9999;
		PlayerPrefs.SetFloat("highTime",highTime);
		}

}

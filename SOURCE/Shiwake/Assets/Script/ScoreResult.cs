using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreResult : MonoBehaviour {
	[SerializeField]
	private GameObject startAnim;
	private int nowScore = 0;
	[SerializeField]
	private GameObject scoreText;
	private Text score;
	[SerializeField]
	private GameObject timeObj;
	private Text timeText;
	private static float highScore;
	[SerializeField]
	private GameObject finish;
	private int subScore = 0;
	public GameObject result;
	private Text resultScore;
	public GameObject resultObj;
	private Text missText;
	public GameObject missObj;
	public GameObject[] sets;
	private bool finishFlg = false;
	[SerializeField]
	private float gameTime = 60;
	
	void Awake(){
		score = scoreText.GetComponent<Text> ();
		timeText = timeObj.GetComponent<Text> ();
		resultScore = resultObj.GetComponent<Text> ();
		missText = missObj.GetComponent<Text> ();
	}
	
	// Use this for initialization
	void Start () {
		Instantiate (startAnim, transform.position, transform.rotation);
		highScore = PlayerPrefs.GetFloat ("highScore");
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("countDwon(Clone)") == null) {
			gameTime -= Time.deltaTime;
			score.text = "" + nowScore;
			timeText.text = "残り" + gameTime.ToString("F0") +"秒";
			if ( gameTime <= 0) {
				sets = GameObject.FindGameObjectsWithTag("Sets");
				foreach (GameObject se in sets) {
					Destroy(se);
				}
				if(finishFlg == false){
					Time.timeScale = 0;
					finishFlg = true;
					finish.SetActive (true);
				}
			}
		}
	}
	
	public void end(){
		finish.SetActive (false);
		nowScore -= subScore;
		missText.text = "ミス回数：" + subScore; 
		resultScore.text = "リザルトスコア：" + nowScore;
		if((highScore < nowScore) || (highScore == null)){
			highScore = nowScore;
			PlayerPrefs.SetFloat("highScore",highScore);
		}
	}
	
	
	public void nowScoreAdd(){
		nowScore ++;
	}
	
	public void scoreSub(){
		subScore++;
	}
	
	public float getGameTime(){
		return gameTime;
	}

}

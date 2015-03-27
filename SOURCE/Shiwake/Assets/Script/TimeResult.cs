using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeResult : MonoBehaviour {
	[SerializeField]
	private GameObject startAnim;
	private float nowTime;
	[SerializeField]
	private GameObject timeText;
	private Text time;
	[SerializeField]
	private float hiyoko = 40;
	[SerializeField]
	private GameObject hiyokoObj;
	private Text hiyokoText;
	private static float highTime;
	[SerializeField]
	private GameObject finish;
	private float addTime = 0;
	public GameObject result;
	private Text resultTime;
	public GameObject resultObj;
	private Text missText;
	public GameObject missObj;
	public GameObject[] sets;
	private bool finishFlg = false;

	void Awake(){
		time = timeText.GetComponent<Text> ();
		hiyokoText = hiyokoObj.GetComponent<Text> ();
		resultTime = resultObj.GetComponent<Text> ();
	 	missText = missObj.GetComponent<Text> ();
	}

	// Use this for initialization
	void Start () {
		Instantiate (startAnim, transform.position, transform.rotation);
		highTime = PlayerPrefs.GetFloat ("highTime");
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("countDwon(Clone)") == null) {
			nowTime += Time.deltaTime;
			time.text = nowTime.ToString("F2");
			hiyokoText.text = "残り" + hiyoko.ToString("F0")+"羽";
			if (hiyoko == 0) {
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
		nowTime += addTime;
		missText.text = "ミス回数：" + addTime.ToString("F0"); 
		resultTime.text = "リザルトタイム：" + nowTime.ToString("F2");
		if((highTime > nowTime) || (highTime == null) || (highTime == 0)){
			highTime = nowTime;
			PlayerPrefs.SetFloat("highTime",highTime);
		}
	}


	public void hiyokoSub(){
		hiyoko--;
	}

	public void timeAdd(){
		addTime ++;
	}

	public float getHiyoko(){
		return hiyoko;
	}

}

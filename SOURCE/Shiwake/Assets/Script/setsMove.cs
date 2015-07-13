using UnityEngine;
using System.Collections;

public class setsMove : MonoBehaviour {
	public GameObject SpawnerObj;
	private Spawns sp;
	[SerializeField]
	private int speed = 1;
	[SerializeField]
	private GameObject obj;
	public bool leftAns = true;
	[SerializeField]
	private GameObject leftObj;
	[SerializeField]
	private GameObject rightObj;
	[SerializeField]
	private GameObject hiyokoObj;
	[SerializeField]
	private GameObject resultObj;
	private TimeResult Trs;
	private ScoreResult Srs;
	private efectSpawner efSpa;
	public GameObject efSpaObj;


    //選択されたモードの認識
	void Awake(){
		efSpa = efSpaObj.GetComponent<efectSpawner> ();
		if (Application.loadedLevelName == "TimeAttack") {              //タイムアタックモード
			resultObj = GameObject.Find ("TimeResult").gameObject;
			Trs = resultObj.GetComponent<TimeResult> ();
		} else if (Application.loadedLevelName == "ScoreAttack") {      //スコアアタックモード
			resultObj = GameObject.Find ("ScoreResult").gameObject;
			Srs = resultObj.GetComponent<ScoreResult> ();
		}
		sp = SpawnerObj.GetComponent<Spawns> ();
	}

	// 降ってくるヒヨコの着地地点
	void Start () {
		obj = GameObject.Find("StopArea").gameObject;
	}
	
	// ヒヨコが着地した後に左右の正誤判定
	void Update () {
		if ((Input.GetKeyDown ("left")) && speed == 0) {                //左キーの入力
			ansLeft ();
		} else if ((Input.GetKeyDown ("right")) && speed == 0) {        //右キーの入力
			ansRight ();
		}
	}

    //ヒヨコの動きの制御
	void FixedUpdate(){
		Move (obj);
	}

    //ヒヨコの移動速度	
	void Move(GameObject target) {
		rigidbody2D.velocity = (target.transform.position - transform.position).normalized * speed;
	}

    //着地判定
	void OnTriggerEnter2D(Collider2D col){ 
		if (col.gameObject.CompareTag("Stop")) { 
			speed = 0;
		}
	}

    //左を選択した場合の処理
	void ansLeft(){
		if (leftAns == true) {                                          //正解
			if (Application.loadedLevelName == "TimeAttack") {          //タイムアタックの場合
				Trs.hiyokoSub ();
			}else if (Application.loadedLevelName == "ScoreAttack") {   //スコアアタックの場合
				Srs.nowScoreAdd();
			}
            SoundManager.Instance.PlaySE(1);
			efSpa.good();
			Destroy (gameObject);
		} else {                                                        //不正解
			if (Application.loadedLevelName == "TimeAttack") {          //タイムアタックの場合
				Trs.hiyokoSub ();
				Trs.timeAdd ();
			}else if (Application.loadedLevelName == "ScoreAttack") {   //スコアアタックの場合
				Srs.scoreSub();
			}
            SoundManager.Instance.PlaySE(2);
			efSpa.bad();
			Destroy (gameObject);
		}
	}

    //右を選択した場合の処理
	void ansRight(){
		if(leftAns == false){                                           //正解
			if (Application.loadedLevelName == "TimeAttack") {          //タイムアタックの場合
				Trs.hiyokoSub ();
			}else if (Application.loadedLevelName == "ScoreAttack") {   //スコアアタックの場合
				Srs.nowScoreAdd();
			}
            SoundManager.Instance.PlaySE(1);
			efSpa.good();
			Destroy (gameObject);
		} else {
			if (Application.loadedLevelName == "TimeAttack") {          //タイムアタックの場合
				Trs.hiyokoSub ();
				Trs.timeAdd ();
			}else if (Application.loadedLevelName == "ScoreAttack") {   //スコアアタックの場合
				Srs.scoreSub();
			}
            SoundManager.Instance.PlaySE(2);
			efSpa.bad();
			Destroy (gameObject);
		}
	}

    //削除後ゲーム終了でなければ問題の表示
	void OnDestroy(){
		if (Application.loadedLevelName == "TimeAttack") {              //タイムアタックの場合
			if (Trs.getHiyoko () != 0) {
				sp.spawnsSet ();
			}
		} else if (Application.loadedLevelName == "ScoreAttack") {      //スコアアタックの場合
			if (Srs.getGameTime () >= 0) {
				sp.spawnsSet ();
			}
		}
	}

}

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
	private right ri;
	private hiyoko hiyo;
	private left lf;
	[SerializeField]
	private GameObject resultObj;
	private TimeResult Trs;
	private ScoreResult Srs;
	private efectSpawner efSpa;
	public GameObject efSpaObj;


	void Awake(){
		efSpa = efSpaObj.GetComponent<efectSpawner> ();
		ri = rightObj.GetComponent<right> ();
		lf = leftObj.GetComponent<left> ();
		hiyo = hiyokoObj.GetComponent<hiyoko> ();
		if (Application.loadedLevelName == "TimeAttack") {
			resultObj = GameObject.Find ("TimeResult").gameObject;
			Trs = resultObj.GetComponent<TimeResult> ();
		} else if (Application.loadedLevelName == "ScoreAttack") {
			resultObj = GameObject.Find ("ScoreResult").gameObject;
			Srs = resultObj.GetComponent<ScoreResult> ();
		}
		sp = SpawnerObj.GetComponent<Spawns> ();
	}

	// Use this for initialization
	void Start () {
		obj = GameObject.Find("StopArea").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown ("left")) && speed == 0) {
			ansLeft ();
		} else if ((Input.GetKeyDown ("right")) && speed == 0) {
			ansRight ();
		}
	}

	void FixedUpdate(){
		Move (obj);
	}
	
	void Move(GameObject target) {
		rigidbody2D.velocity = (target.transform.position - transform.position).normalized * speed;
	}


	void OnTriggerEnter2D(Collider2D col){ // 衝突判定
		if (col.gameObject.CompareTag("Stop")) { 
			speed = 0;
		}
	}

	void ansLeft(){
		if (leftAns == true) {
			if (Application.loadedLevelName == "TimeAttack") {
				Trs.hiyokoSub ();
			}else if (Application.loadedLevelName == "ScoreAttack") {
				Srs.nowScoreAdd();
			}
            SoundManager.Instance.PlaySE(1);
			efSpa.good();
			hiyo.srideLest ();
			ri.sride ();
			lf.sride ();
			Destroy (gameObject);
		} else {
			if (Application.loadedLevelName == "TimeAttack") {
				Trs.hiyokoSub ();
				Trs.timeAdd ();
			}else if (Application.loadedLevelName == "ScoreAttack") {
				Srs.scoreSub();
			}
            SoundManager.Instance.PlaySE(2);
			efSpa.bad();
			ri.sride ();
			lf.sride ();
			hiyo.srideLest ();
			Destroy (gameObject);
		}
	}

	void ansRight(){
		if(leftAns == false){
			if (Application.loadedLevelName == "TimeAttack") {
				Trs.hiyokoSub ();
			}else if (Application.loadedLevelName == "ScoreAttack") {
				Srs.nowScoreAdd();
			}
            SoundManager.Instance.PlaySE(1);
			efSpa.good();
			hiyo.srideRight ();
			ri.sride ();
			lf.sride ();
			Destroy (gameObject);
		} else {
			if (Application.loadedLevelName == "TimeAttack") {
				Trs.hiyokoSub ();
				Trs.timeAdd ();
			}else if (Application.loadedLevelName == "ScoreAttack") {
				Srs.scoreSub();
			}
            SoundManager.Instance.PlaySE(2);
			efSpa.bad();
			ri.sride ();
			lf.sride ();
			hiyo.srideRight ();
			Destroy (gameObject);
		}
	}

	void OnDestroy(){
		if (Application.loadedLevelName == "TimeAttack") {
			if (Trs.getHiyoko () != 0) {
				sp.spawnsSet ();
			}
		} else if (Application.loadedLevelName == "ScoreAttack") {
			if (Srs.getGameTime () >= 0) {
				sp.spawnsSet ();
			}
		}
	}

}

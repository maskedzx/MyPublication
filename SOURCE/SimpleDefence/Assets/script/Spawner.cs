using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*スポナーの処理*/
public class Spawner : MonoBehaviour {
    private int cnt;
    [SerializeField]
    private int[] spawnSpace = { 250, 250, 250, 220, 220 };
    private int radSpawns;
    [SerializeField]
    private int level;
    [SerializeField]
    private int holl = 0;
    private float[] spawnArea = { -15, -10, -5, 0, 5, 10, 15 };
    [SerializeField]
    private GameObject[] enemy;
    private int enemySu = 1;
    private static int tmpLevel = 1;
    public GameObject levelObj;
    private Text levelText;
    [SerializeField]
    private int maxLevel = 5;
    [SerializeField]
    private GameObject gameClearObj;
    [SerializeField]
    private GameObject levelClearObj;
    [SerializeField]
    private GameObject canvasObj;
    private int radEnemy = 0;
    private float[] radSpawnEnemy = { 1, 2, 3, 3, 3 };
    private float[] radEnemySu = { 3, 3, 3, 4, 4 };

    /*GetComponent処理*/
    void Awake(){
        levelText = levelObj.GetComponent<Text>();
    }

	/*初期化処理*/
	void Start () {
        cnt = 0;
        level = tmpLevel;
        levelText.text = "現在のレベル：" + level;
	}

    /*levelのgetter・setter*/
    public int Level{
        set { this.level = value; }
        get{return this.level;}
    }

	
	/*常時起動する処理*/
	void Update () {
        cnt++;
        if (cnt >= spawnSpace[level-1] && Time.timeScale != 0){ //cntがspawneSpaceを満たしたらスポーン処理
            RandSpawnSu();
            RandSpawns();
            cnt = 0;
        }

	}

    /*生成されるエネミーの数だけ生成処理*/
    void RandSpawns(){
        for (int i = enemySu; i > 0; i--){
            radEnemy = (int)(Random.Range(0, radSpawnEnemy[level-1]));  //生成されるエネミーの決定
            radSpawns = (int)(Random.Range(0, holl - 1));
            Instantiate(enemy[radEnemy], new Vector3(spawnArea[radSpawns], 3, 49), Quaternion.Euler(0, 90, 90));
        }
    }

    /*スポーンするエネミーの数の決定*/
    void RandSpawnSu()
    {
        enemySu = (int)(Random.Range(1, radEnemySu[level-1]));
    }

    /*クリア時の処理*/
    public void Clear(){
        SoundManager.Instance.StopBGM();    //BGM停止
        if (level == maxLevel){     //最終レベルのときゲームクリア表示
            Time.timeScale = 0;
            canvasObj.SetActive(false);
            gameClearObj.SetActive(true);
        }else{  //最終レベル以外のときレベルクリアを表示
            Time.timeScale = 0;
            canvasObj.SetActive(false);
            levelClearObj.SetActive(true);
        }
        
    }

    /*レベルの上昇*/
    public void levelUp(){
        tmpLevel++;
    }

    /*レベルのリセット*/
    public void levelReset(){
        tmpLevel = 1;
    }

}

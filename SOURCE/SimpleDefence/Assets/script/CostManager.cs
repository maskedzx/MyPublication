using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*コスト関連の処理*/
public class CostManager : MonoBehaviour {
    private int cost;
    public GameObject costObj;
    private Text costText;
    private int cnt;
    [SerializeField]
    private GameObject wallManagerObj;
    private WallManager wallManager;
    [SerializeField]
    private int[] costTime = {160,160,160,180,180};
    private int level;
    [SerializeField]
    private GameObject spawnerObj;
    private Spawner spawner;

    /*GetComponent処理*/
    void Awake(){
        costText = costObj.GetComponent<Text>();
        wallManager = wallManagerObj.GetComponent<WallManager>();
        spawner = spawnerObj.GetComponent<Spawner>();
    }

	/*初期化*/
	void Start () {
        cost = 0;
        level = spawner.Level;
	}
	
	/*常時起動する処理*/
	void Update () {
        cnt++;  //cntのカウントアップ
        if (cnt >= costTime[level-1]){  //cntが一定数になったらコスト＋１
            cost++;
            cnt = 0;
        }
        if (cost != 0 && Time.timeScale != 0){  //コストが1以上のときに壁生成受付
            summonWall();
        }
        costText.text = "残りコスト：" + cost;    //残コストの表示
    }

    /*コスト消費メソッド*/
    public void costSub(){
        cost--;
    }

    /*1～7キーに対応する壁生成メソッドの呼び出し*/
    void summonWall()
    {

        if (Input.GetKeyUp("1"))
        {
            wallManager.spawnWall(1);
        }
        else if (Input.GetKeyUp("2"))
        {
            wallManager.spawnWall(2);
        }
        else if (Input.GetKeyUp("3"))
        {
            wallManager.spawnWall(3);
        }
        else if (Input.GetKeyUp("4"))
        {
            wallManager.spawnWall(4);
        }
        else if (Input.GetKeyUp("5"))
        {
            wallManager.spawnWall(5);
        }
        else if (Input.GetKeyUp("6"))
        {
            wallManager.spawnWall(6);
        }
        else if (Input.GetKeyUp("7"))
        {
            wallManager.spawnWall(7);
        }

    }

}

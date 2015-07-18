using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Result : MonoBehaviour {
    private bool gameOver;
    [SerializeField]
    private float[] gameTime = { 30, 45, 60, 75, 90 };
    public GameObject timeObj;
    private Text timeText;
    private int playerHP = 5;
    private int level;
    [SerializeField]
    private GameObject spawnerObj;
    private Spawner spawner;
    public GameObject LifeObj;
    private Text lifeText;
    [SerializeField]
    private GameObject Canvas;
    [SerializeField]
    private GameObject GameOverObj;

    /*GetComponent処理*/
    void Awake(){
        timeText = timeObj.GetComponent<Text>();
        spawner = spawnerObj.GetComponent<Spawner>();
        lifeText = LifeObj.GetComponent<Text>();
    }

	/*初期化処理*/
	void Start () {
        Time.timeScale = 1;
        gameOver = false;
        level = spawner.Level;
        SoundManager.Instance.PlayBGM(1);   //BGM再生
	}
	
	/*常時起動する処理*/
	void Update () {
        if (gameOver == false){ //ゲームオーバーでないとき
            gameTime[level-1] -= Time.deltaTime;    //時間管理
            if (gameTime[level-1] <= 0){    //時間が0になったらクリア
                spawner.Clear();    //クリアメソッドの起動
            }
            timeText.text = "残り防衛時間：" + gameTime[level-1].ToString("f1"); //残防衛時間の表示
            lifeText.text = "残りライフ：" + playerHP;    //残ライフの表示
        }
	}

    /*ゲームオーバー直後の処理*/
    public void GameOver(){
        SoundManager.Instance.StopBGM();    //BGMの停止
        Time.timeScale = 0; //時間の停止
        Canvas.SetActive(false);    //Canvasの非表示
        GameOverObj.SetActive(true);    //GameOverObjの表示
    }

    /*ダメージ処理*/
    public void damege(){
        playerHP--; //ライフの減少
        if (playerHP == 0){
            GameOver(); //ライフが0になったらゲームオーバーメソッド呼び出し
        }
    }

}

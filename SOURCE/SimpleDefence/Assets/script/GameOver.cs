using UnityEngine;
using System.Collections;

/*ゲームオーバー時の処理*/
public class GameOver : MonoBehaviour {

    [SerializeField]
    private GameObject spawnerObj;
    private Spawner spawner;

    /*GetComponent処理*/
	void Awake () {
        spawner = spawnerObj.GetComponent<Spawner>();
	}
	
    /*キー入力の監視*/
	void Update () {
        if (Input.GetKeyUp(KeyCode.R)){ //Rキーの場合
            Application.LoadLevel("main");  //メインシーンを再起動
        }
        else if (Input.GetKeyUp(KeyCode.T)){    //Tキーの場合
            spawner.levelReset();   //レベルのリセット
            Application.LoadLevel("title"); //タイトルシーンへ
        }
	}
}

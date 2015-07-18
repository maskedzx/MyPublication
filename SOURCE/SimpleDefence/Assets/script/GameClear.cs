using UnityEngine;
using System.Collections;

/*ゲームクリア時の処理*/
public class GameClear : MonoBehaviour {

    [SerializeField]
    private GameObject spawnerObj;
    private Spawner spawner;

    /*GetComponent処理*/
    void Awake(){
        spawner = spawnerObj.GetComponent<Spawner>();
    }

    /*Tキーの入力監視*/
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T)){
            spawner.levelReset();   //レベルのリセット
            Application.LoadLevel("title"); //タイトルシーンへ
        }
    }
}

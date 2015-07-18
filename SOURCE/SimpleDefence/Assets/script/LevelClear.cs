using UnityEngine;
using System.Collections;

/*レベルクリア時の処理*/
public class LevelClear : MonoBehaviour {

    [SerializeField]
    private GameObject spawnerObj;
    private Spawner spawner;

    /*GetComponent処理*/
    void Awake(){
        spawner = spawnerObj.GetComponent<Spawner>();
    }

    /*キー入力の監視*/
	void Update () {
        if (Input.GetKeyUp(KeyCode.N))
        {
            spawner.levelUp();  //レベル上昇メソッドの起動
            Application.LoadLevel("main");  //メインシーンの再起動
        }
	}
}
